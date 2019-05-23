using Grand.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grand.Plugin.DiscountAmount.BuyXGet1Free
{
    public class DiscountAmountSettings : ISettings
    {
        public int Quantity { get; set; }
    }
}
