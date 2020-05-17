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

    [Route(RoutePrefix + "account-txns")]
    public class AccountTransactionController: AccountellaControllerBase
    {
        IAccountTransactionService _accTxnService;
        public AccountTransactionController(IAccountTransactionService accTxnService)
        {
            this._accTxnService = accTxnService;
        }

        // GET: api/account-txns
        [HttpGet()]
        public async Task<IList<AccTxnDto>> GetAccountTypes()
        {
            return await _accTxnService.GetTransactions(null);
        }
        // GET: api/account-txns/2
        [HttpGet("{id}", Name = "GetAccountTypeById")]
        public async Task<AccTxnDto> GetAccountType(string id)
        {
            return (await _accTxnService.GetTransactions(id)).FirstOrDefault();
        }

        // POST: api/account-txns
        [HttpPost()]
        public async Task<AccTxnDto> AddTransaction(AccTxnDto txnToAdd)
        {
            return await _accTxnService.AddTransaction(txnToAdd);
        }
    }
}
