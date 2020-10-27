using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Grand.Plugin.Misc.ExamplePlugin.Middleware
{
    public class TestMiddleware
    {
        private readonly RequestDelegate _next;

        public TestMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            //call the next middleware in the request pipeline
            await _next(context);
        }
    }
}
