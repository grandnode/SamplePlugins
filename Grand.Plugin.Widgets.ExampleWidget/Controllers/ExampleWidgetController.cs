using Grand.Framework.Controllers;
using Grand.Framework.Mvc.Filters;
using Grand.Plugin.Widgets.ExampleWidget.Models;
using Grand.Services.Configuration;
using Grand.Services.Localization;
using Microsoft.AspNetCore.Mvc;

namespace Grand.Plugin.Misc.ExamplePlugin.Controllers
{
    [Area("Admin")]
    [AuthorizeAdmin]
    public class ExampleWidgetController : BasePluginController
    {
        #region fields
        private readonly ExampleWidgetSettings _settings;
        private readonly ISettingService _settingService;
        private readonly ILocalizationService _localizationService;
        #endregion

        #region ctor
        public ExampleWidgetController(ExampleWidgetSettings settings,
            ISettingService settingService,
            ILocalizationService localizationService)
        {
            _settings = settings;
            _settingService = settingService;
            _localizationService = localizationService;
        }
        #endregion

        #region methods
        public IActionResult Configure()
        {
            var model = new ConfigurationModel();


            return View("~/Plugins/Widgets.ExampleWidget/Views/Configure.cshtml",model);
        }
        [HttpPost]
        public IActionResult Configure(ConfigurationModel model)
        {


            _settingService.SaveSetting(_settings); // save our settings !
            _settingService.ClearCache(); 

            SuccessNotification(_localizationService.GetResource("Admin.Plugins.Saved"));
            return Configure();
        }

        #endregion
    }
}
