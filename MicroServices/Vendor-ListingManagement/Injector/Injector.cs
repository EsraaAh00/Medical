using Vendor_ListingManagement.Interfaces.Repositories;
using Vendor_ListingManagement.Interfaces.Services;
using Vendor_ListingManagement.Repositories;
using Vendor_ListingManagement.Services;
using Vendor_ListingManagement.Context;
using SharedModels.BaseRepository;
namespace Vendor_ListingManagement.Injector
{
    public class Injector
    {
        static ListingManagementContext context = new ListingManagementContext();
        public static void Inject(IServiceCollection services)
        {
            InjectServices(services);
            InjectReposities(services);
            InjectContext(services);
        }
        private static void InjectServices(IServiceCollection services)
        {
            services.AddSingleton<IListingItemsTaxService, ListingItemsTaxService>();
            services.AddSingleton<IListingItemsPricingService, ListingItemsPricingService>();
            services.AddSingleton<IListingItemPhotosService, ListingItemPhotosService>();
            services.AddSingleton<IListingItemDetailService, ListingItemDetailService>();
            services.AddSingleton<IListingItemService, ListingItemService>();
            services.AddSingleton<IItemCategoriesService, ItemCategoriesService>();
            services.AddSingleton<IListingItemDetailSettingService, ListingItemDetailSettingService>();
            services.AddSingleton<IEnumService, EnumService>();
            services.AddSingleton<IItemSubCategoriesService, ItemSubCategoriesService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services
        }
        private static void InjectReposities(IServiceCollection services)
        {
            services.AddSingleton<IListingItemsTaxRepository, ListingItemsTaxRepository>();
            services.AddSingleton<IListingItemsPricingRepository, ListingItemsPricingRepository>();
            services.AddSingleton<IListingItemPhotosRepository, ListingItemPhotosRepository>();
            services.AddSingleton<IListingItemDetailRepository, ListingItemDetailRepository>();
            services.AddSingleton<IListingItemRepository, ListingItemRepository>();
            services.AddSingleton<IItemCategoriesRepository, ItemCategoriesRepository>();
            services.AddSingleton<IListingItemDetailSettingRepository, ListingItemDetailSettingRepository>();
            services.AddSingleton<IItemSubCategoriesRepository, ItemSubCategoriesRepository>();
            //reposities
        }
        private static void InjectContext(IServiceCollection services)
        {
            services.AddSingleton<ListingItemsTaxRepository>(services => new ListingItemsTaxRepository(context));
            services.AddSingleton<ListingItemsPricingRepository>(services => new ListingItemsPricingRepository(context));
            services.AddSingleton<ListingItemPhotosRepository>(services => new ListingItemPhotosRepository(context));
            services.AddSingleton<ListingItemDetailRepository>(services => new ListingItemDetailRepository(context));
            services.AddSingleton<ListingItemRepository>(services => new ListingItemRepository(context));
            services.AddSingleton<ItemCategoriesRepository>(services => new ItemCategoriesRepository(context));
            services.AddSingleton<ListingItemDetailSettingRepository>(services => new ListingItemDetailSettingRepository(context));
            services.AddSingleton<ItemSubCategoriesRepository>(services => new ItemSubCategoriesRepository(context));
            services.AddSingleton<IDbContext, ListingManagementContext>();
        }
    }
}
