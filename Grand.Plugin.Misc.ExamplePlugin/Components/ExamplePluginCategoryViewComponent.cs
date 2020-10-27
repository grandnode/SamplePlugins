using Microsoft.AspNetCore.Mvc;

namespace Grand.Plugin.Misc.ExamplePlugin.Components
{
    [ViewComponent(Name = "examplePluginCategoryTab")]
    public class ExamplePluginCategoryViewComponent : ViewComponent
    {

        public ExamplePluginCategoryViewComponent()
        {
            
        }

        public IViewComponentResult Invoke(string widgetZone, object additionalData)
        {
            if (widgetZone == "category_details_tabs")
            {
                var model = additionalData as Grand.Web.Areas.Admin.Models.Catalog.CategoryModel;
                if (model != null)
                {
                    if (!string.IsNullOrEmpty(model.Id))
                    {
                        ViewData["CategoryId"] = model.Id;
                       
                        return View("~/Plugins/Misc.ExamplePlugin/Views/Category.cshtml");
                    }
                }
            }
            return Content("");
        }
    }
}
