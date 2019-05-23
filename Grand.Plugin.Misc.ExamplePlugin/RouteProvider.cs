using Grand.Framework.Mvc.Routing;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grand.Plugin.Misc.ExamplePlugin
{
    public class RouteProvider : IRouteProvider
    {
        public void RegisterRoutes(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute("Plugin.Misc.ExamplePlugin",
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
