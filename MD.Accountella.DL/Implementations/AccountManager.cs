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
    using MD.Accountella.DomainObjects;

    public class AccountManager : IAccountManager
    {
        private readonly AccountellaDbContext _dbContext;
        public AccountManager(AccountellaDbContext dbContext)
        {
            this._dbContext = dbContext;
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
