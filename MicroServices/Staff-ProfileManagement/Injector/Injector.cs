using SharedModels.BaseRepository;
using Staff_StaffProfileManagement.Services;
using Staff_StaffProfileManagement.Interfaces.Services;
using Staff_StaffProfileManagement.Interfaces.Repositories;
using Staff_StaffProfileManagement.Context;
using Staff_StaffProfileManagement.Repositories;
namespace Staff_StaffProfileManagement.Injector
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
            services.AddSingleton<IStaffAwardService, StaffAwardService>();
            services.AddSingleton<IStaffExperienceService, StaffExperienceService>();
            services.AddSingleton<IStaffRequestService, StaffRequestService>();
            services.AddSingleton<IStaffService, StaffService>();
            services.AddSingleton<IStaffWorkScheduleService, StaffWorkScheduleService>();
            services.AddSingleton<IFilterService, FilterService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services
        }
        private static void InjectReposities(IServiceCollection services)
        {
            services.AddSingleton<IStaffAwardRepository, StaffAwardRepository>();
            services.AddSingleton<IStaffExperienceRepository, StaffExperienceRepository>();
            services.AddSingleton<IStaffRepository, StaffRepository>();
            services.AddSingleton<IStaffRequestRepository, StaffRequestRepository>();
            services.AddSingleton<IStaffWorkScheduleRepository, StaffWorkScheduleRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //reposities
        }
        private static void InjectContext(IServiceCollection services)
        {
            services.AddSingleton(services => new StaffAwardRepository(context));
            services.AddSingleton(services => new StaffExperienceRepository(context));
            services.AddSingleton(services => new StaffRepository(context));
            services.AddSingleton(services => new StaffRequestRepository(context));
            services.AddSingleton(services => new StaffWorkScheduleRepository(context));
            services.AddSingleton<IDbContext, ProfileManagementContext>();
        }
    }
}