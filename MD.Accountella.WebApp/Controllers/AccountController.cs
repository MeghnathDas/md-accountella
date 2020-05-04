/// <summary>
/// Author: Meghnath Das
/// Description:
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.WebApp.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using MD.Accountella.BL;
    using MD.Accountella.Core.RestConcerns;
    using MD.Accountella.DataTransferObjects;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [Route(RoutePrefix + "accounts")]
    public class AccountController: AccountellaControllerBase
    {
        IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            this._accountService = accountService;
        }

        // GET: api/accounts
        [HttpGet]
        public ICollection<AccountDto> Get()
        {
            return _accountService.GetAccounts(null);
        }

        // GET: api/accounts/5
        [HttpGet("{id}", Name = "GetAccount")]
        public AccountDto Get(string id)
        {
            return _accountService.GetAccounts(id).FirstOrDefault();
        }

        // POST: api/accounts
        [HttpPost]
        public AccountDto Post(AccountDto value)
        {
            return _accountService.AddAccount(value);
        }

        // PUT: api/accounts/5
        [HttpPut("{id}")]
        public void Put(string id, AccountDto value)
        {
            _accountService.UpdateAccount(id, value);
        }

        // DELETE: api/accounts/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _accountService.RemoveAccount(id);
        }
    }
}
