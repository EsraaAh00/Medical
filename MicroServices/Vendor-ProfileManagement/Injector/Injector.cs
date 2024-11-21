using Vendor_ProfileManagement.Interfaces.Repositories;
using Vendor_ProfileManagement.Interfaces.Services;
using Vendor_ProfileManagement.Repositories;
using Vendor_ProfileManagement.Services;
using Vendor_ProfileManagement.Context;
using SharedModels.BaseRepository;
namespace Vendor_ProfileManagement.Injector
{
    public class Injector
    {
        static ProfileManagementContext context = new ProfileManagementContext();
        public static void Inject(IServiceCollection services)
        {
            InjectServices(services);
            InjectReposities(services);
            InjectContext(services);
        }
        private static void InjectServices(IServiceCollection services)
        {
            //services.AddSingleton<IVendorBusinessPolicyService, VendorBusinessPolicyService>();
            //services.AddSingleton<IBusinessAffiliationInfoService, BusinessAffiliationInfoService>();
            services.AddSingleton<IVendorBusinessPaymentMethodService, VendorBusinessPaymentMethodService>();
            services.AddSingleton<IPaymentMethodService, PaymentMethodService>();
            services.AddSingleton<IVendorBusinessGalleryService, VendorBusinessGalleryService>();
            services.AddSingleton<IVendorBusinessAreaAttractionService, VendorBusinessAreaAttractionService>();
            services.AddSingleton<IVendorBusinessFeatureService, VendorBusinessFeatureService>();
            services.AddSingleton<IBusinessTypeFeatureService, BusinessTypeFeatureService>();
            services.AddSingleton<IVendorBusinessFacilityService, VendorBusinessFacilityService>();
            services.AddSingleton<IFacilityService, FacilityService>();
            services.AddSingleton<IOptionService, OptionService>();
            services.AddSingleton<IFeatureService, FeatureService>();
            services.AddSingleton<IVendorBusinessService, VendorBusinessService>();
            services.AddSingleton<IVendorService, VendorService>();
            services.AddSingleton<IDiscountPlanService, DiscountPlanService>();
            services.AddSingleton<IMarketingPlanService, MarketingPlanService>();
            services.AddSingleton<ISubscriptionPlanService, SubscriptionPlanService>();
            services.AddSingleton<IVendorRequestService, VendorRequestService>();
            services.AddSingleton<IBusinessTypeCategoryService, BusinessTypeCategoryService>();
            services.AddSingleton<IBusinessTypeService, BusinessTypeService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services
        }
        private static void InjectReposities(IServiceCollection services)
        {
            services.AddSingleton<IVendorBusinessPolicyRepository, VendorBusinessPolicyRepository>();
            services.AddSingleton<IBusinessAffiliationInfoRepository, BusinessAffiliationInfoRepository>();
            services.AddSingleton<IVendorBusinessPaymentMethodRepository, VendorBusinessPaymentMethodRepository>();
            services.AddSingleton<IPaymentMethodRepository, PaymentMethodRepository>();
            services.AddSingleton<IVendorBusinessGalleryRepository, VendorBusinessGalleryRepository>();
            services.AddSingleton<IVendorBusinessAreaAttractionRepository, VendorBusinessAreaAttractionRepository>();
            services.AddSingleton<IVendorBusinessFeatureRepository, VendorBusinessFeatureRepository>();
            services.AddSingleton<IBusinessTypeFeatureRepository, BusinessTypeFeatureRepository>();
            services.AddSingleton<IVendorBusinessFacilityRepository, VendorBusinessFacilityRepository>();
            services.AddSingleton<IFacilityRepository, FacilityRepository>();
            services.AddSingleton<IOptionRepository, OptionRepository>();
            services.AddSingleton<IFeatureRepository, FeatureRepository>();
            services.AddSingleton<IVendorBusinessRepository, VendorBusinessRepository>();
            services.AddSingleton<IVendorRepository, VendorRepository>();
            services.AddSingleton<IDiscountPlanRepository, DiscountPlanRepository>();
            services.AddSingleton<IMarketingPlanRepository, MarketingPlanRepository>();
            services.AddSingleton<ISubscriptionPlanRepository, SubscriptionPlanRepository>();
            services.AddSingleton<IVendorRequestRepository, VendorRequestRepository>();
            services.AddSingleton<IBusinessTypeCategoryRepository, BusinessTypeCategoryRepository>();
            services.AddSingleton<IBusinessTypeRepository, BusinessTypeRepository>();
            //reposities
        }
        private static void InjectContext(IServiceCollection services)
        {
            services.AddSingleton<VendorBusinessPolicyRepository>(services => new VendorBusinessPolicyRepository(context));
            services.AddSingleton<BusinessAffiliationInfoRepository>(services => new BusinessAffiliationInfoRepository(context));
            services.AddSingleton<VendorBusinessPaymentMethodRepository>(services => new VendorBusinessPaymentMethodRepository(context));
            services.AddSingleton<PaymentMethodRepository>(services => new PaymentMethodRepository(context));
            services.AddSingleton<VendorBusinessGalleryRepository>(services => new VendorBusinessGalleryRepository(context));
            services.AddSingleton<VendorBusinessAreaAttractionRepository>(services => new VendorBusinessAreaAttractionRepository(context));
            services.AddSingleton<VendorBusinessFeatureRepository>(services => new VendorBusinessFeatureRepository(context));
            services.AddSingleton<BusinessTypeFeatureRepository>(services => new BusinessTypeFeatureRepository(context));
            services.AddSingleton<VendorBusinessFacilityRepository>(services => new VendorBusinessFacilityRepository(context));
            services.AddSingleton<FacilityRepository>(services => new FacilityRepository(context));
            services.AddSingleton<OptionRepository>(services => new OptionRepository(context));
            services.AddSingleton<FeatureRepository>(services => new FeatureRepository(context));
            services.AddSingleton<VendorBusinessRepository>(services => new VendorBusinessRepository(context));
            services.AddSingleton<VendorRepository>(services => new VendorRepository(context));
            services.AddSingleton<DiscountPlanRepository>(services => new DiscountPlanRepository(context));
            services.AddSingleton<MarketingPlanRepository>(services => new MarketingPlanRepository(context));
            services.AddSingleton<SubscriptionPlanRepository>(services => new SubscriptionPlanRepository(context));
            services.AddSingleton<VendorRequestRepository>(services => new VendorRequestRepository(context));
            services.AddSingleton<BusinessTypeCategoryRepository>(services => new BusinessTypeCategoryRepository(context));
            services.AddSingleton<BusinessTypeRepository>(services => new BusinessTypeRepository(context));
            services.AddSingleton<IDbContext, ProfileManagementContext>();
        }
    }
}