using Grand.Core.Routing;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace Grand.Plugin.Misc.ExamplePlugin
{
    public class RouteProvider : IRouteProvider
    {
        public void RegisterRoutes(IEndpointRouteBuilder routeBuilder)
        {
            routeBuilder.MapControllerRoute("Plugin.Misc.ExamplePlugin",
                 "login",
                 new { controller = "ExamplePlugin", action = "SignIn" }
            );
        }
        public int Priority {
            get {
                return 10;
            }
        }
    }
}
