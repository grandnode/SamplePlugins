using Grand.Core.Configuration;
using Grand.Framework.Controllers;
using Grand.Framework.Mvc.Filters;
using Grand.Plugin.Misc.ExamplePlugin.Models;
using Grand.Services.Common;
using Grand.Services.Configuration;
using Grand.Services.Localization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grand.Plugin.Misc.ExamplePlugin.Controllers
{
    [Area("Admin")]
    [AuthorizeAdmin]
    public class ExamplePluginController : BasePluginController
    {
        #region fields
        private readonly ExamplePluginSettings _settings;

        #endregion

        #region ctor
        public ExamplePluginController(ExamplePluginSettings settings)
        {
            this._settings = settings;
        }
        #endregion

        #region methods

        [ServiceFilter(typeof(TestActionFilter2))]
        public IActionResult Configure()
        {
            var model = new ConfigurationModel();
            model.IsMale = _settings.IsMale;
            model.Login = _settings.Login;
            model.Password = _settings.Password;

            return View("~/Plugins/Misc.ExamplePlugin/Views/Configure.cshtml",model);
        }

        #endregion
    }
}
