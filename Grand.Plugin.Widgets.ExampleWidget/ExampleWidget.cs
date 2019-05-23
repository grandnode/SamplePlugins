using Grand.Core;
using Grand.Core.Plugins;
using Grand.Plugin.Widgets.ExampleWidget;
using Grand.Services.Cms;
using Grand.Services.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Grand.Plugin.Misc.ExamplePlugin
{
    public class ExampleWidget : BasePlugin, IWidgetPlugin
    {
        private readonly IWebHelper _webHelper;

        public ExampleWidget(IWebHelper webHelper)
        {
            _webHelper = webHelper;
        }
        #region Methods

        public override async Task Install()
        {
            await base.Install();
        }
        public override async Task Uninstall()
        {
            await base.Uninstall();
        }
        public override string GetConfigurationPageUrl()
        {
            return $"{_webHelper.GetStoreLocation()}Admin/ExampleWidget/Configure";
        }

        public IList<string> GetWidgetZones()
        {
            return new List<string>
            {
                ExampleWidgetsDefaults.WidgetZoneCategoryPage,
                ExampleWidgetsDefaults.WidgetZoneHomePage,
                ExampleWidgetsDefaults.WidgetZoneManufacturerPage
            };
        }

        public void GetPublicViewComponent(string widgetZone, out string viewComponentName)
        {
            viewComponentName = "Grand.Plugin.Widgets.ExampleWidget";
        }

        #endregion
    }
}
