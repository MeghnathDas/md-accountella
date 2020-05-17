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

        #region "Account Management"
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

        // GET: api/account-map/accounts-by-type/2
        [HttpGet("accounts-by-type/{accTypeId}")]
        public ICollection<AccountDto> GetAccountsByType(string accTypeId)
        {
            return _accountService.GetAccountsByCategory(accTypeId).ToList();
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

        //// DELETE: api/account-map/accounts/5
        //[HttpDelete("accounts/{id}")]
        //public void Delete(string id)
        //{
        //    _accountService.RemoveAccount(id);
        //}
        #endregion

        #region "Account Groups and Types"
        // GET: api/account-map/account-groups
        [HttpGet("account-groups")]
        public ICollection<EntityCategoryDto> GetAccountGroups()
        {
            return _accountService.GetGroups().ToList();
        }

        // GET: api/account-map/account-types
        [HttpGet("account-types")]
        public ICollection<EntityCategoryDto> GetAccountTypes()
        {
            var subCatgs = _accountService.GetGroups()
                .Where(x => x.SubCategories != null && x.SubCategories.Any())
                .SelectMany(catg => catg.SubCategories);
            return subCatgs.ToList();
        }

        // POST: api/account-map/account-types
        [HttpPost("account-types")]
        public EntityCategoryDto AddAccountType(EntityCategoryDto typeToAdd)
        {
            return _accountService.AddSubCategory(typeToAdd);
        }

        // DELETE: api/account-map/account-types/3
        [HttpDelete("account-types/{accTypeId}")]
        public void RemoveAccountType(string accTypeId)
        {
            _accountService.RemoveSubCategory(accTypeId);
        }
        #endregion
    }
}
