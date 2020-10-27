using Grand.Core;
using Grand.Domain.Catalog;
using Grand.Domain.Customers;
using Grand.Domain.Discounts;
using Grand.Core.Plugins;
using Grand.Services.Discounts;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Grand.Plugin.DiscountAmount.BuyXGet1Free
{
    public class DiscountAmountPlugin : BasePlugin, IDiscountAmountProvider
    {
        private readonly IWebHelper _webHelper;
        private readonly IWorkContext _workContext;
        private readonly DiscountAmountSettings _settings;

        public  DiscountAmountPlugin(IWebHelper webHelper, IWorkContext workContext,
            DiscountAmountSettings settings)
        {
            _webHelper = webHelper;
            _workContext = workContext;
            _settings = settings;
        }

        public async Task<decimal> DiscountAmount(Discount discount, Customer customer, Product product, decimal amount)
        {
            if (product != null)
            {
                var qty = _workContext.CurrentCustomer.ShoppingCartItems.Where(x => x.ProductId == product.Id).Sum(x => x.Quantity);
                if (qty >= _settings.Quantity)
                {
                    //var price = (qty / _count) * (amount / qty);
                    var price = Math.DivRem(qty, _settings.Quantity, out int ignored) * (amount / qty);
                    return await Task.FromResult(price);
                }
            }

            return await Task.FromResult(0);
        }
        public override string GetConfigurationPageUrl()
        {
            return $"{_webHelper.GetStoreLocation()}Admin/DiscountAmount/Configure";
        }
        public override async Task Install()
        {
           await base.Install();
        }

        public override async Task Uninstall()
        {
            //locales
            await base.Uninstall();
        }

    }
}
