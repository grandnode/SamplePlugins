using Grand.Core;
using Grand.Core.Caching;
using Grand.Domain.Catalog;
using Grand.Domain.Data;
using Grand.Services.Catalog;
using Grand.Services.Security;
using Grand.Services.Stores;
using MediatR;
using System;
using System.Threading.Tasks;

namespace Grand.Plugin.Misc.ExamplePlugin.Services
{
    public class OverrideProductService : ProductService, IProductService
    {
        #region fields
        
        #endregion

        #region ctor
        public OverrideProductService(ICacheManager cacheManager,
            IRepository<Product> productRepository,
            IRepository<ProductDeleted> productDeletedRepository,
            IProductAttributeService productAttributeService,
            IProductAttributeParser productAttributeParser,
            IWorkContext workContext,
            CatalogSettings catalogSettings,
            IMediator mediator,
            IAclService aclService,
            IStoreMappingService storeMappingService
            ) :base(cacheManager,
            productRepository,
            productDeletedRepository,
            productAttributeService,
            productAttributeParser,
            workContext,
            mediator,
            aclService,
            storeMappingService,
            catalogSettings)
        {
            
        }
        #endregion

        #region methods

        public override async Task DeleteProduct(Product product)
        {
            throw new Exception("You cant delete products!");
        }

        #endregion

    }
}
