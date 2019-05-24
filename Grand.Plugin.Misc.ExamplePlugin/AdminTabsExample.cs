using Grand.Framework.Events;
using Grand.Services.Events;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Grand.Plugin.Misc.ExamplePlugin
{
    public class AdminTabsExample : IConsumer<AdminTabStripCreated>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AdminTabsExample(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Task HandleEvent(AdminTabStripCreated eventMessage)
        {
            if (eventMessage.TabStripName == "category-edit")
            {
                var categoryId = Convert.ToString(_httpContextAccessor.HttpContext.GetRouteValue("ID"));
                eventMessage.BlocksToRender.Add(("test new tab", new Microsoft.AspNetCore.Html.HtmlString($"<div>TEST {categoryId}</div>")));
            }
            return Task.CompletedTask;
        }
    }
}
