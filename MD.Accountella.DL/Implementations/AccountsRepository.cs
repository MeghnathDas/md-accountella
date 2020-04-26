/// <summary>
/// Author: Meghnath Das
/// Description: Account Manager class, implementation of IAccountManager
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.DL
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using Amazon.DynamoDBv2.DataModel;
    using MD.Accountella.DomainObjects;

    public class AccountsRepository : IAccountsRepository
    {
        private readonly AccountellaDbContext _dbContext;
        public AccountsRepository(AccountellaDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public Account AddAccount(Account accToAdd)
        {
            accToAdd.Id = Guid.NewGuid().ToString();
            try
            {
                _dbContext.SaveAsync<Account>(accToAdd).Wait();
            }
            catch (Exception)
            {
                return null;
            }
            return accToAdd;
        }

        public Task<List<Account>> GetAccounts(string id)
        {
            List<ScanCondition> conditions = new List<ScanCondition>();
            // conditions.Add(new ScanCondition("IsDeleted", ScanOperator.Equal, 0));
            return this._dbContext.ScanAsync<Account>(conditions).GetRemainingAsync();
        }

        public bool RemoveAccount(string id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateAccount(Account accToAdd)
        {
            throw new NotImplementedException();
        }
    }
}
