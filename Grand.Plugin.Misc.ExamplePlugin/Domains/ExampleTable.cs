using Grand.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grand.Plugin.Misc.ExamplePlugin.Domains
{
    public class ExampleTable : BaseEntity
    {
        public string SampleText { get; set; }
        public bool SampleFlag { get; set; }
        public int SampleInt { get; set; }
    }
}
