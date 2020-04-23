/// <summary>
/// Author: Meghnath Das
/// Description: 
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.Core.RestConcerns
{
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Text;
    public class LoggingActionFilter : IActionFilter
    {
        private readonly ILogger _logger;
        public LoggingActionFilter(ILogger<LoggingActionFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogDebug("Started execution of {0}",
                context.ActionDescriptor.DisplayName);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogDebug("Ended execution of {0}",
                context.ActionDescriptor.DisplayName);
        }
    }
}
