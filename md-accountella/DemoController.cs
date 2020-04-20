using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MD.Accountella.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MD.Accountella.WebApp.Controllers
{
    [Route("api/aws")]
    public class DemoController : Controller
    {
        private readonly AwsConfig _config;
        public DemoController(IOptions<AwsConfig> config)
        {
            _config = config.Value;
        }

        [HttpGet]
        // GET: /<controller>/
        public string Get()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(_config);
        }
    }
}
