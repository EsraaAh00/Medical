using SharedModels.BaseRepository;
using Facility_FacilityProfileManagement.Context;
using Facility_FacilityProfileManagement.Interfaces.Repositories;
using Facility_FacilityProfileManagement.Interfaces.Services;
using Facility_FacilityProfileManagement.Repositories;
using Facility_FacilityProfileManagement.Services;
namespace Facility_FacilityProfileManagement.Injector
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
            services.AddSingleton<IFacilityListingService, FacilityListingService>();
            services.AddSingleton<IFacilityRequestService, FacilityRequestService>();
            services.AddSingleton<IFacilityService, FacilityService>();
            services.AddSingleton<IFacilityWorkScheduleService, FacilityWorkScheduleService>();
            services.AddSingleton<IFilterService, FilterService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services
        }
        private static void InjectReposities(IServiceCollection services)
        {
            services.AddSingleton<IFacilityListingRepository, FacilityListingRepository>();
            services.AddSingleton<IFacilityRepository, FacilityRepository>();
            services.AddSingleton<IFacilityRequestRepository, FacilityRequestRepository>();
            services.AddSingleton<IFacilityWorkScheduleRepository, FacilityWorkScheduleRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //reposities
        }
        private static void InjectContext(IServiceCollection services)
        {
            services.AddSingleton(services => new FacilityListingRepository(context));
            services.AddSingleton(services => new FacilityRepository(context));
            services.AddSingleton(services => new FacilityRequestRepository(context));
            services.AddSingleton(services => new FacilityWorkScheduleRepository(context));
            services.AddSingleton<IDbContext, ProfileManagementContext>();
        }
    }
}