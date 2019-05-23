using Grand.Plugin.Widgets.ExampleWidget.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Grand.Plugin.Widgets.ExampleWidget.Compontents
{
    [ViewComponent(Name = "Grand.Plugin.Widgets.ExampleWidget")]
    public class ExampleWidgetViewCompontent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string widgetZone, object additionalData = null)
        {
            var model = new PublicInfoModel();
            model.exampleText = "Example text";

            return View("/Plugins/Widgets.ExampleWidget/Views/PublicInfo.cshtml",model);
        }
    }
}
