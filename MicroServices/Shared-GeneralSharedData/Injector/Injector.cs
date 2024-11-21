using Shared_GeneralSharedData.Interfaces.Repositories;
using Shared_GeneralSharedData.Interfaces.Services;
using Shared_GeneralSharedData.Repositories;
using Shared_GeneralSharedData.Services;
using Shared_GeneralSharedData.Context;
using SharedModels.BaseRepository;
namespace Shared_GeneralSharedData.Injector
{
    public class Injector
    {
        static GeneralSharedDataContext context = new GeneralSharedDataContext();
        public static void Inject(IServiceCollection services)
        {
            InjectServices(services);
            InjectReposities(services);
            InjectContext(services);
        }
        private static void InjectServices(IServiceCollection services)
        {
            services.AddSingleton<IClassificationService, ClassificationService>();
            services.AddSingleton<IDegreeService, DegreeService>();
            services.AddSingleton<ISpecialityService, SpecialityService>();
            services.AddSingleton<ICurrencyService, CurrencyService>();
            services.AddSingleton<IRegionService, RegionService>();
            services.AddSingleton<IGovernorateService, GovernorateService>();
            services.AddSingleton<ICountryService, CountryService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services
        }
        private static void InjectReposities(IServiceCollection services)
        {
            services.AddSingleton<IClassificationRepository, ClassificationRepository>();
            services.AddSingleton<IDegreeRepository, DegreeRepository>();
            services.AddSingleton<ISpecialityRepository, SpecialityRepository>();
            services.AddSingleton<ICurrencyRepository, CurrencyRepository>();
            services.AddSingleton<IRegionRepository, RegionRepository>();
            services.AddSingleton<IGovernorateRepository, GovernorateRepository>();
            services.AddSingleton<ICountryRepository, CountryRepository>();
            //reposities
        }
        private static void InjectContext(IServiceCollection services)
        {
            services.AddSingleton<ClassificationRepository>(services => new ClassificationRepository(context));
            services.AddSingleton<DegreeRepository>(services => new DegreeRepository(context));
            services.AddSingleton<SpecialityRepository>(services => new SpecialityRepository(context));
            services.AddSingleton<CurrencyRepository>(services => new CurrencyRepository(context));
            services.AddSingleton<RegionRepository>(services => new RegionRepository(context));
            services.AddSingleton<GovernorateRepository>(services => new GovernorateRepository(context));
            services.AddSingleton<CountryRepository>(services => new CountryRepository(context));
            services.AddSingleton<IDbContext, GeneralSharedDataContext>();
        }
    }
}