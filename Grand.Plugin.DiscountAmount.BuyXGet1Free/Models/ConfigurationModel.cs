using FluentValidation;
using Grand.Plugin.DiscountAmount.BuyXGet1Free.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grand.Plugin.DiscountAmount.BuyXGet1Free.Models
{    
    public class ConfigurationModel
    {
        public int Quantity { get; set; }
    }
}
