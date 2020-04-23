/// <summary>
/// Author: Meghnath Das
/// Description: 
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.Core.RestConcerns
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.AspNetCore.Mvc;

    [ServiceFilter(typeof(LoggingActionFilter))]
    [ApiController]
    public class AccountellaControllerBase : ControllerBase
    {
    }
}
