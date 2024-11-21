using Operation_OperationsManagement.Interfaces.Repositories;
using Operation_OperationsManagement.Interfaces.Services;
using Operation_OperationsManagement.Repositories;
using Operation_OperationsManagement.Services;
using Operation_OperationsManagement.Context;
using SharedModels.BaseRepository;
namespace Operation_OperationsManagement.Injector
{
    public class Injector
    {
        static OperationsManagementContext context = new OperationsManagementContext();
        public static void Inject(IServiceCollection services)
        {
            InjectServices(services);
            InjectReposities(services);
            InjectContext(services);
        }
        private static void InjectServices(IServiceCollection services)
        {
            services.AddSingleton<ITicketService, TicketService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services
        }
        private static void InjectReposities(IServiceCollection services)
        {
            services.AddSingleton<ITicketRepository, TicketRepository>();
            //reposities
        }
        private static void InjectContext(IServiceCollection services)
        {
            services.AddSingleton<TicketRepository>(services => new TicketRepository(context));
            services.AddSingleton<IDbContext, OperationsManagementContext>();
        }
    }
}