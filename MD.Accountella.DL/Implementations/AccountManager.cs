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
    using MD.Accountella.DL.Core;
    using MD.Accountella.DomainObjects;

    public class AccountManager : IAccountManager
    {
        private readonly IDynamoDBStore _dbStore;
        public AccountManager(IDynamoDBStore dynamoDBStore)
        {
            this._dbStore = dynamoDBStore;
        }
        public Account AddAccount(Account accToAdd)
        {
            return new Account();
        }

        public Account GetAccounts(string id)
        {
            return new Account() { Id = id };
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
