using System_ClientRelationMangement.Interfaces.Repositories;
using System_ClientRelationMangement.Interfaces.Services;
using System_ClientRelationMangement.Repositories;
using System_ClientRelationMangement.Services;
using System_ClientRelationMangement.Context;
using SharedModels.BaseRepository;
using System_ClientRelationMangement.Entities;
namespace System_ClientRelationMangement.Injector
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
            services.AddSingleton<ComplaintActionRepository>(services => new ComplaintActionRepository(context));
            services.AddSingleton<ComplaintRepository>(services => new ComplaintRepository(context));
            services.AddSingleton<SanctionRepository>(services => new SanctionRepository(context));
        }
    }
}