/// <summary>
/// Author: Meghnath Das
/// Description: 
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.BL
{
    using MD.Accountella.DataTransferObjects;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public interface IAccountService
    {
        public IEnumerable<AccountDto> GetAccounts(string id);
        public AccountDto AddAccount(AccountDto accountToAdd);
        bool AlterAccount(int id, AccountDto value);
        bool RemoveAccount(int id);
    }
}
