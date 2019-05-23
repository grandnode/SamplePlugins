using Grand.Core.Infrastructure;
using Grand.Plugin.Misc.ExamplePlugin.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grand.Plugin.Misc.ExamplePlugin
{
    public class Startup : IGrandStartup
    {
        public int Order {
            get { return 550; }
        }

        public void Configure(IApplicationBuilder application)
        {
            application.UseMiddleware<TestMiddleware>();
        }

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MvcOptions>(config =>
            {
                config.Filters.Add<TestActionFilter2>();
            });
        }
    }
}
