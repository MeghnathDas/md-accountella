/// <summary>
/// Author: Meghnath Das
/// Description: Delivers navigation menu related services
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace md_accountella.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using MD.Accountella.DataTransferObjects;
    using Microsoft.AspNetCore.Mvc;
    using MD.Accountella.BL;

    [Route("api/nav-nodes")]
    public class NavMenuController : Controller
    {
        private INavMenuService _navMnuService;
        public NavMenuController(INavMenuService navMnuService)
        {
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
