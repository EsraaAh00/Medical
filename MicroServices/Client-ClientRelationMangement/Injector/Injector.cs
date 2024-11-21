using SharedModels.BaseRepository;
using Client_ClientRelationMangement.Interfaces.Repositories;
using Client_ClientRelationMangement.Context;
using Client_ClientRelationMangement.Interfaces.Services;
using Client_ClientRelationMangement.Services;
using Client_ClientRelationMangement.Repositories;
namespace Client_ClientRelationMangement.Injector
{
    public class Injector
    {
        static ClientRelationMangementContext context = new ClientRelationMangementContext();
        public static void Inject(IServiceCollection services)
        {
            InjectServices(services);
            InjectReposities(services);
            InjectContext(services);
        }
        private static void InjectServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services
            services.AddSingleton<IComplaintActionService, ComplaintActionService>();
            services.AddSingleton<IComplaintService, ComplaintService>();
            services.AddSingleton<ISanctionService, SanctionService>();
        }
        private static void InjectReposities(IServiceCollection services)
        {
            //reposities
            services.AddSingleton<IComplaintActionRepository, ComplaintActionRepository>();
            services.AddSingleton<IComplaintRepository, ComplaintRepository>();
            services.AddSingleton<ISanctionRepository, SanctionRepository>();
        }
        private static void InjectContext(IServiceCollection services)
        {
            services.AddSingleton<IDbContext, ClientRelationMangementContext>();
            services.AddSingleton(services => new ComplaintActionRepository(context));
            services.AddSingleton(services => new ComplaintRepository(context));
            services.AddSingleton(services => new SanctionRepository(context));
        }
    }
}