using Grand.Domain;

namespace Grand.Plugin.Misc.ExamplePlugin.Domains
{
    public class ExampleTable : BaseEntity
    {
        public string SampleText { get; set; }
        public bool SampleFlag { get; set; }
        public int SampleInt { get; set; }
    }
}
