using Grand.Core;
using Grand.Core.Caching;
using Grand.Core.Data;
using Grand.Core.Domain.Catalog;
using Grand.Core.Domain.Common;
using Grand.Core.Domain.Customers;
using Grand.Core.Domain.Localization;
using Grand.Core.Domain.Orders;
using Grand.Core.Domain.Security;
using Grand.Core.Domain.Seo;
using Grand.Core.Domain.Shipping;
using Grand.Services.Catalog;
using Grand.Services.Customers;
using Grand.Services.Events;
using Grand.Services.Localization;
using Grand.Services.Messages;
using Grand.Services.Security;
using Grand.Services.Shipping;
using Grand.Services.Stores;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grand.Plugin.Misc.ExamplePlugin.Services
{
    public class OverrideProductService : ProductService, IProductService
    {
        #region fields
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<ProductReview> _productReviewRepository;
        private readonly IRepository<AclRecord> _aclRepository;
        private readonly IRepository<ProductTag> _productTagRepository;
        private readonly IRepository<UrlRecord> _urlRecordRepository;
        private readonly IRepository<Customer> _customerRepository;
        private readonly IRepository<CustomerRoleProduct> _customerRoleProductRepository;
        private readonly IRepository<CustomerTagProduct> _customerTagProductRepository;
        private readonly IRepository<ProductDeleted> _productDeletedRepository;
        private readonly IRepository<CustomerProduct> _customerProductRepository;
        private readonly IProductAttributeService _productAttributeService;
        private readonly IProductAttributeParser _productAttributeParser;
        private readonly ISpecificationAttributeService _specificationAttributeService;
        private readonly ILanguageService _languageService;
        private readonly IWorkflowMessageService _workflowMessageService;
        private readonly IDataProvider _dataProvider;
        private readonly ICacheManager _cacheManager;
        private readonly IWorkContext _workContext;
        private readonly IStoreContext _storeContext;
        private readonly LocalizationSettings _localizationSettings;
        private readonly CommonSettings _commonSettings;
        private readonly CatalogSettings _catalogSettings;
        private readonly IEventPublisher _eventPublisher;
        private readonly IAclService _aclService;
        private readonly IStoreMappingService _storeMappingService;
        private readonly IServiceProvider _serviceProvider;
        #endregion

        #region ctor
        public OverrideProductService(ICacheManager cacheManager,
            IRepository<Product> productRepository,
            IRepository<ProductReview> productReviewRepository,
            IRepository<AclRecord> aclRepository,
            IRepository<UrlRecord> urlRecordRepository,
            IRepository<Customer> customerRepository,
            IRepository<CustomerRoleProduct> customerRoleProductRepository,
            IRepository<CustomerTagProduct> customerTagProductRepository,
            IRepository<ProductDeleted> productDeletedRepository,
            IRepository<CustomerProduct> customerProductRepository,
            IProductAttributeService productAttributeService,
            IProductAttributeParser productAttributeParser,
            ISpecificationAttributeService specificationAttributeService,
            ILanguageService languageService,
            IWorkflowMessageService workflowMessageService,
            IDataProvider dataProvider,
            IWorkContext workContext,
            IStoreContext storeContext,
            LocalizationSettings localizationSettings,
            CommonSettings commonSettings,
            CatalogSettings catalogSettings,
            IEventPublisher eventPublisher,
            IAclService aclService,
            IStoreMappingService storeMappingService,
            IRepository<ProductTag> productTagRepository,
            IServiceProvider serviceProvider) :base(cacheManager, productRepository, productReviewRepository, aclRepository, urlRecordRepository,
                customerRepository, customerRoleProductRepository, customerTagProductRepository, productDeletedRepository, customerProductRepository,
                productAttributeService, productAttributeParser, specificationAttributeService, languageService, workflowMessageService,
                dataProvider, workContext, storeContext, localizationSettings, commonSettings, catalogSettings, eventPublisher, aclService,
                storeMappingService, productTagRepository, serviceProvider)
        {
            this._cacheManager = cacheManager;
            this._productRepository = productRepository;
            this._productReviewRepository = productReviewRepository;
            this._aclRepository = aclRepository;
            this._urlRecordRepository = urlRecordRepository;
            this._customerRepository = customerRepository;
            this._customerRoleProductRepository = customerRoleProductRepository;
            this._customerTagProductRepository = customerTagProductRepository;
            this._productDeletedRepository = productDeletedRepository;
            this._productAttributeService = productAttributeService;
            this._productAttributeParser = productAttributeParser;
            this._specificationAttributeService = specificationAttributeService;
            this._languageService = languageService;
            this._workflowMessageService = workflowMessageService;
            this._dataProvider = dataProvider;
            this._workContext = workContext;
            this._storeContext = storeContext;
            this._localizationSettings = localizationSettings;
            this._commonSettings = commonSettings;
            this._catalogSettings = catalogSettings;
            this._eventPublisher = eventPublisher;
            this._aclService = aclService;
            this._storeMappingService = storeMappingService;
            this._productTagRepository = productTagRepository;
            this._customerProductRepository = customerProductRepository;
            this._serviceProvider = serviceProvider;
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
