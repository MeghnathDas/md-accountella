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
    using Amazon.DynamoDBv2.Model;
    using MD.Accountella.DomainObjects;
    using MD.Accountella.DL.Helper;

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
            //var obj = new Account();
            //var tblNme = DbUtility.GetTableName<Account>();
            //var tblNme2 = DbUtility.GetTableName(obj.GetType());
            //var fieldNme = nameof(obj.Category);
            List<ScanCondition> conditions = new List<ScanCondition>();
            //conditions.Add(new ScanCondition("IsDeleted", ScanOperator.Equal, 0));
            return this._dbContext.ScanAsync<Account>(conditions).GetRemainingAsync();
        }

        public bool RemoveAccount(string id)
        {
            //_dbContext.Delete<Account>(acc => !acc.IsReadOnly && acc.Id == id);
            //var request = new DeleteItemRequest
            //{
            //    TableName = tableName,
            //    Key = new Dictionary<string, AttributeValue>()
            //    { { "StudentId", new AttributeValue {S=studentId} } }
            //};
            //var res = this._dbContext.DeleteAsync<Account>(1);
            ////var response = await this._dbContext.DeleteItemAsync(request);
            return true;
        }

        public bool UpdateAccount(Account accToAdd)
        {
            throw new NotImplementedException();
        }
    }
}
