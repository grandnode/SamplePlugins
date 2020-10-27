using Grand.Domain.Configuration;

namespace Grand.Plugin.Misc.ExamplePlugin
{
    public class ExamplePluginSettings : ISettings
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public bool IsMale { get; set; }
    }
}
