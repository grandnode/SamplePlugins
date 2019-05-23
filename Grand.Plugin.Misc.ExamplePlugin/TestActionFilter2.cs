using Grand.Services.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Grand.Plugin.Misc.ExamplePlugin
{
    public class TestActionFilter2 : TypeFilterAttribute
    {
        public TestActionFilter2(ILogger logger) : base(typeof(TestFilter))
        {
            
        }

        private class TestFilter : IAsyncActionFilter
        {
            private readonly ILogger _logger;
            public TestFilter(ILogger logger)
            {
                _logger = logger;
            }
            public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
            {
                await _logger.InsertLog(Core.Domain.Logging.LogLevel.Information, "filter ");
                await next();
            }
        }
    }
}
