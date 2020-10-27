using Grand.Core.Infrastructure;
using Grand.Plugin.Misc.ExamplePlugin.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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

        public void Configure(IApplicationBuilder application, IWebHostEnvironment webHostEnvironment)
        {
            
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
