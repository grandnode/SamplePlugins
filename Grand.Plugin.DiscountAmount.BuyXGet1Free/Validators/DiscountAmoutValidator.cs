using FluentValidation;
using Grand.Plugin.DiscountAmount.BuyXGet1Free.Models;
using Grand.Services.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grand.Plugin.DiscountAmount.BuyXGet1Free.Validators
{
    public class DiscountAmoutValidator : AbstractValidator<ConfigurationModel>
    {
        public DiscountAmoutValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Quantity).GreaterThan(1).WithMessage(localizationService.GetResource("Quantity should be greater than 1"));
        }
    }
}
