/// <summary>
/// Author: Meghnath Das
/// Description: Delivers navigation menu related services
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.BL
{
    using MD.Accountella.DL;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Accounts : IAccounts
    {
        private readonly IAccountManager _accountManager;
        public Accounts(IAccountManager accountManager)
        {
            this._accountManager = accountManager;
        }
        public void GetAccounts()
        {
            this._accountManager.GetAccounts(System.Guid.NewGuid().ToString());
        }
    }
}
