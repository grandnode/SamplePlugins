using Grand.Domain;

namespace Grand.Plugin.Widgets.ExampleWidget.Domains
{
    public class ExampleTable : BaseEntity
    {
        public string SampleText { get; set; }
        public bool SampleFlag { get; set; }
        public int SampleInt { get; set; }
    }
}
