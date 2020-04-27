using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MD.Accountella.BL;
using MD.Accountella.Core.RestConcerns;
using MD.Accountella.DataTransferObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MD.Accountella.WebApp.Controllers
{
    [Route("api/accounts")]
    public class AccountManagerController: AccountellaControllerBase
    {
        IAccountService _accountService;
        public AccountManagerController(ILogger<AccountManagerController> logger, IAccountService accountService)
        {
            this._accountService = accountService;
        }

        // GET: api/accounts
        [HttpGet]
        public IEnumerable<AccountDto> Get()
        {
            return _accountService.GetAccounts(null);
        }

        // GET: api/accounts/5
        [HttpGet("{id}", Name = "Get")]
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
        public void Put(int id, AccountDto value)
        {
            _accountService.AlterAccount(id, value);
        }

        // DELETE: api/accounts/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _accountService.RemoveAccount(id);
        }
    }
}
