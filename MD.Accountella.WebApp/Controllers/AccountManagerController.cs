using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MD.Accountella.Core.RestConcerns;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MD.Accountella.WebApp.Controllers
{
    [Route("api/accounts")]
    public class AccountManagerController: AccountellaControllerBase
    {
        public AccountManagerController(ILogger<AccountManagerController> logger)
        {
        }

        // GET: api/AccountManager
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/AccountManager/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/AccountManager
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/AccountManager/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
