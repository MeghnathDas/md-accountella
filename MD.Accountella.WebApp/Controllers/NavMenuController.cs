/// <summary>
/// Author: Meghnath Das
/// Description: Delivers navigation menu related services
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.WebApp.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using MD.Accountella.DataTransferObjects;
    using Microsoft.AspNetCore.Mvc;
    using MD.Accountella.BL;
    using Microsoft.Extensions.Logging;
    using MD.Accountella.Core.RestConcerns;

    [Route("api/nav-nodes")]
    public class NavMenuController: AccountellaControllerBase
    {
        private readonly INavMenuService _navMnuService;
        private readonly IAccountService _accounts;
        public NavMenuController(ILogger<NavMenuController> logger,
            INavMenuService navMnuService, IAccountService accounts)
        {
            this._accounts = accounts;
            this._navMnuService = navMnuService;
        }

        // GET: api/nav-nodes
        [HttpGet]
        public ICollection<NavNode> Get()
        {
            return this._navMnuService.GetPermisibleNavNodes();
        }
    }
}
