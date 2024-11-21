using Operation_FinanceManagement.Interfaces.Repositories;
using Operation_FinanceManagement.Interfaces.Services;
using Operation_FinanceManagement.Repositories;
using Operation_FinanceManagement.Services;
using Operation_FinanceManagement.Context;
using SharedModels.BaseRepository;
namespace Operation_FinanceManagement.Injector
{
    public class Injector
    {
        static FinanceManagementContext context = new FinanceManagementContext();
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
            services.AddSingleton<ITransactionService, TransactionService>();

        }
        private static void InjectReposities(IServiceCollection services)
        {
            //reposities
            services.AddSingleton<ITransactionRepository, TransactionRepository>();
        }
        private static void InjectContext(IServiceCollection services)
        {
          services.AddSingleton<IDbContext, FinanceManagementContext>();
            services.AddSingleton<TransactionRepository>(services => new TransactionRepository(context));

        }
    }
}