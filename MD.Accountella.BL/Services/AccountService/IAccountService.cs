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
        ICollection<AccountDto> GetAccounts(string id);
        AccountDto AddAccount(AccountDto accountToAdd);
        void UpdateAccount(string id, AccountDto accountToAlter);
        void RemoveAccount(string id);
    }
}
