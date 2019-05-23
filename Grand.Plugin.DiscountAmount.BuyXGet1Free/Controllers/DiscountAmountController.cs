using Grand.Framework.Controllers;
using Grand.Framework.Mvc.Filters;
using Grand.Plugin.DiscountAmount.BuyXGet1Free.Models;
using Grand.Services.Configuration;
using Grand.Services.Localization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Grand.Plugin.DiscountAmount.BuyXGet1Free.Controllers
{
    [Area("Admin")]
    [AuthorizeAdmin]
    public class DiscountAmountController  : BasePluginController
    {
        #region fields
        private readonly DiscountAmountSettings _settings;
        private readonly ISettingService _settingService;
        private readonly ILocalizationService _localizationService;
        #endregion
        #region ctor
        public DiscountAmountController(DiscountAmountSettings settings,ISettingService settingService, ILocalizationService localizationService)
        {
            _settings = settings;
            _settingService = settingService;
            _localizationService = localizationService;
        }
        #endregion
        public async Task<IActionResult> Configure()
        {
            var model = new ConfigurationModel();
            model.Quantity = _settings.Quantity;
            return await Task.FromResult(View("~/Plugins/DiscountAmount.BuyXGet1Free/Views/Configure.cshtml", model));
        }
        [HttpPost]
        public async Task<IActionResult> Configure(ConfigurationModel model)
        {
            if (ModelState.IsValid)
            {
                _settings.Quantity = model.Quantity;
                await _settingService.SaveSetting(_settings);
                SuccessNotification(_localizationService.GetResource("Admin.Plugins.Saved"));
            }

            return await Configure();
        }
    }
}
