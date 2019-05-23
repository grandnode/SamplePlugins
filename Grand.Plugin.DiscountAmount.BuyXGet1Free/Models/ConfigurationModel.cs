using FluentValidation.Attributes;
using Grand.Plugin.DiscountAmount.BuyXGet1Free.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grand.Plugin.DiscountAmount.BuyXGet1Free.Models
{
    [Validator(typeof(DiscountAmoutValidator))]
    public class ConfigurationModel
    {
        public int Quantity { get; set; }
    }
}
