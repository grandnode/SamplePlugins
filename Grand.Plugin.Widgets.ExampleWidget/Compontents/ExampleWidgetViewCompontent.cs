using Grand.Plugin.Widgets.ExampleWidget.Models;
using Microsoft.AspNetCore.Mvc;

namespace Grand.Plugin.Widgets.ExampleWidget.Compontents
{
    [ViewComponent(Name = "Grand.Plugin.Widgets.ExampleWidget")]
    public class ExampleWidgetViewCompontent : ViewComponent
    {
        public IViewComponentResult Invoke(string widgetZone, object additionalData)
        {
            var model = new PublicInfoModel();
            model.ExampleText = "Example text";

            return View("/Plugins/Widgets.ExampleWidget/Views/PublicInfo.cshtml",model);
        }
    }
}
