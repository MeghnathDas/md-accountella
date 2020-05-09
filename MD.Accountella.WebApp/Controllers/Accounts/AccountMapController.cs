/// <summary>
/// Author: Meghnath Das
/// Description:
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.WebApp.Controllers
{
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

    [Route(RoutePrefix + "account-map")]
    public class AccountMapController: AccountellaControllerBase
    {
        IAccountService _accountService;
        public AccountMapController(IAccountService accountService)
        {
            this._accountService = accountService;
        }

        // GET: api/account-map/accounts
        [HttpGet("accounts", Name = "GetAllAccounts")]
        public ICollection<AccountDto> GetAllAccounts()
        {
            return _accountService.GetAccounts(null).ToList();
        }

        // GET: api/account-map/accounts/5
        [HttpGet("accounts/{id}", Name = "GetAccountById")]
        public AccountDto GetAccountById(string id)
        {
            return _accountService.GetAccounts(id).FirstOrDefault();
        }

        // POST: api/account-map/accounts
        [HttpPost("accounts")]
        public AccountDto Post(AccountDto value)
        {
            return _accountService.AddAccount(value);
        }

        // PUT: api/account-map/accounts/5
        [HttpPut("accounts/{id}")]
        public void Put(string id, AccountDto value)
        {
            _accountService.UpdateAccount(id, value);
        }

        // DELETE: api/account-map/accounts/5
        [HttpDelete("accounts/{id}")]
        public void Delete(string id)
        {
            _accountService.RemoveAccount(id);
        }

        // GET: api/account-map/categories
        [HttpGet("[action]", Name = "GetAccountCategories")]
        public ICollection<EntityCategoryDto> Categories()
        {
            return _accountService.GetCategories().ToList();
        }

        // GET: api/account-map/accounts-by-category/2
        [HttpGet("accounts-by-category/{subCategoryId}", Name = "GetAccountsByCategory")]
        public ICollection<AccountDto> GetAccountsByCategory(string subCategoryId)
        {
            return _accountService.GetAccountsByCategory(subCategoryId).ToList();
        }
    }
}
