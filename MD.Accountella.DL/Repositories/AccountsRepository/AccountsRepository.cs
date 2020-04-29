/// <summary>
/// Author: Meghnath Das
/// Description: Account repository, implementation of IAccountsRepository
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.DL
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using Amazon.DynamoDBv2.DataModel;
    using Amazon.DynamoDBv2.Model;
    using MD.Accountella.DomainObjects;
    using MD.Accountella.DL.Helper;
    using Amazon.DynamoDBv2;
    using Amazon.DynamoDBv2.DocumentModel;
    using System.Linq;
    using Amazon.Runtime;

    public class AccountsRepository : IAccountsRepository
    {
        private readonly AccountellaDbContext _dbContext;
        public AccountsRepository(AccountellaDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public Account AddAccount(Account accToAdd)
        {
            if (string.IsNullOrWhiteSpace(accToAdd.Name))
                throw new Exception("Account name must be provided");

            var accountMatches = _dbContext
                .ScanAsync<Account>(new ScanCondition[] {
                    new ScanCondition(nameof(accToAdd.Name),
                        ScanOperator.Equal,
                        new object [] { accToAdd.Name }
                    )
                }).GetRemainingAsync().Result;
            if (accountMatches.Any())
                throw new Exception("Account name already exists");

            if (string.IsNullOrWhiteSpace(accToAdd._CategoryId))
                throw new Exception("Account category must be assigned");

            EntityCategory catg = _dbContext.LoadAsync<EntityCategory>(accToAdd._CategoryId).Result;
            if (catg == null)
                throw new Exception("Invalid category assigned");


            accToAdd.Id = Guid.NewGuid().ToString();
            accToAdd.CreatedOn = DateTime.Now;
            accToAdd.IsActive = true;
            accToAdd.IsReadOnly = false;

            try
            {
                _dbContext.SaveAsync<Account>(accToAdd).Wait();
            }
            catch (Exception)
            {
                return null;
            }
            return _dbContext.LoadAsync<Account>(accToAdd.Id).Result;
        }
        public List<Account> GetAccounts(string id)
        {
            List<ScanCondition> conditions = new List<ScanCondition>();
            if (!string.IsNullOrWhiteSpace(id))
                conditions.Add(new ScanCondition(nameof(Account.Id), ScanOperator.Equal, id));
            return _dbContext.ScanAsync<Account>(conditions).GetRemainingAsync().Result;
        }
        public void UpdateAccount(string id, Account accountToUpdate)
        {
            try
            {
                var accFound = GetAccounts(id);
                if (!accFound.Any())
                    throw new KeyNotFoundException("Item requested for update not found");

                accountToUpdate.Id = id;
                accountToUpdate.IsReadOnly = accFound.First().IsReadOnly;
                if (accFound.First().IsReadOnly)
                    accountToUpdate._CategoryId = accFound.First()._CategoryId;
                accountToUpdate.LastModifiedOn = DateTime.Now;
                _dbContext.SaveAsync<Account>(accountToUpdate).Wait();
            }
            catch (AmazonDynamoDBException aDbEx)
            {
                throw new Exception("Data Error: " + aDbEx.Message);
            }
            catch (AmazonServiceException e) { throw new Exception("DB Service Error: " + e.Message); }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void RemoveAccount(string id)
        {
            Account accToDel = _dbContext.LoadAsync<Account>(id).Result;
            if (accToDel == null)
                throw new KeyNotFoundException("No item found");
            if (accToDel.IsReadOnly)
                throw new Exception("Requested item is read only, hence cannot be deleted");
            this._dbContext.DeleteAsync<Account>(accToDel).Wait();
        }
    }
}
