using Client_ClientProfileManagement.Context;
using Client_ClientProfileManagement.Interfaces.Repositories;
using Client_ClientProfileManagement.Interfaces.Services;
using Client_ClientProfileManagement.Repositories;
using Client_ClientProfileManagement.Services;
using SharedModels.BaseRepository;
namespace Client_ClientProfileManagement.Injector
{
    public class Injector
    {
        static ClientProfileManagementContext context = new ClientProfileManagementContext();
        public static void Inject(IServiceCollection services)
        {
            InjectServices(services);
            InjectReposities(services);
            InjectContext(services);
        }
        private static void InjectServices(IServiceCollection services)
        {
            services.AddSingleton<IClientAnalysisResultService, ClientAnalysisResultService>();
            services.AddSingleton<IClientExternalMedicalReportService, ClientExternalMedicalReportService>();
            services.AddSingleton<IClientInsuranceService, ClientInsuranceService>();
            services.AddSingleton<IClientMedicalProfileService, ClientMedicalProfileService>();
            services.AddSingleton<IClientMedicalReportService, ClientMedicalReportService>();
            services.AddSingleton<IClientPrescribtionService, ClientPrescribtionService>();
            services.AddSingleton<IClientService, ClientService>();
            services.AddSingleton<IClientTherapyProgramService, ClientTherapyProgramService>();
            services.AddSingleton<IClientXrayService, ClientXrayService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services
        }
        private static void InjectReposities(IServiceCollection services)
        {
            services.AddSingleton<IClientAnalysisResultRepository, ClientAnalysisResultRepository>();
            services.AddSingleton<IClientExternalMedicalReportRepository, ClientExternalMedicalReportRepository>();
            services.AddSingleton<IClientInsuranceRepository, ClientInsuranceRepository>();
            services.AddSingleton<IClientMedicalProfileRepository, ClientMedicalProfileRepository>();
            services.AddSingleton<IClientMedicalReportRepository, ClientMedicalReportRepository>();
            services.AddSingleton<IClientPrescribtionRepository, ClientPrescribtionRepository>();
            services.AddSingleton<IClientRepository, ClientRepository>();
            services.AddSingleton<IClientTherapyProgramRepository, ClientTherapyProgramRepository>();
            services.AddSingleton<IClientXrayRepository, ClientXrayRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //reposities
        }
        private static void InjectContext(IServiceCollection services)
        {
            services.AddSingleton<ClientAnalysisResultRepository>(services => new ClientAnalysisResultRepository(context));
            services.AddSingleton<ClientExternalMedicalReportRepository>(services => new ClientExternalMedicalReportRepository(context));
            services.AddSingleton<ClientInsuranceRepository>(services => new ClientInsuranceRepository(context));
            services.AddSingleton<ClientMedicalProfileRepository>(services => new ClientMedicalProfileRepository(context));
            services.AddSingleton<ClientMedicalReportRepository>(services => new ClientMedicalReportRepository(context));
            services.AddSingleton<ClientPrescribtionRepository>(services => new ClientPrescribtionRepository(context));
            services.AddSingleton<ClientRepository>(services => new ClientRepository(context));
            services.AddSingleton<ClientTherapyProgramRepository>(services => new ClientTherapyProgramRepository(context));
            services.AddSingleton<ClientXrayRepository>(services => new ClientXrayRepository(context));
            services.AddSingleton<IDbContext, ClientProfileManagementContext>();
        }
    }
}