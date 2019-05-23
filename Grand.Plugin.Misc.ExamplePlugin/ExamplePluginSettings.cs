using Grand.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grand.Plugin.Misc.ExamplePlugin
{
    public class ExamplePluginSettings : ISettings
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public bool IsMale { get; set; }
    }
}
