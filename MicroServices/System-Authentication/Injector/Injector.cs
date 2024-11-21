using System_Authentication.Interfaces.Repositories;
using System_Authentication.Interfaces.Services;
using System_Authentication.Repositories;
using System_Authentication.Services;
using System_Authentication.Context;
using SharedModels.BaseRepository;
using Microsoft.AspNetCore.Identity;
using System_Authentication.Entities;
namespace System_Authentication.Injector
{
    public static class Injector
    {
        public static AuthenticationContext context = new AuthenticationContext();
        public static void Inject(IServiceCollection services)
        {
            InjectServices(services);
            InjectReposities(services);
            InjectContext(services);
        }
        private static void InjectServices(IServiceCollection services)
        {
            services.AddSingleton<IUserActionRoleService, UserActionRoleService>();
            services.AddSingleton<IRoleGroupService, RoleGroupService>(); services.AddSingleton<IActionRoleService, ActionRoleService>();
            services.AddTransient<IUserService, UserService>();
            services.AddSingleton<IUserRoleGroupService, UserRoleGroupService>();
            services.AddTransient<ICustomAuthenticationService, CustomAuthenticationService>();
            services.AddSingleton<IRankService, RankService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
        private static void InjectReposities(IServiceCollection services)
        {
            services.AddSingleton<IUserActionRoleRepository, UserActionRoleRepository>();
            services.AddSingleton<IUserRoleGroupRepository, UserRoleGroupRepository>();
            services.AddSingleton<IRoleGroupRepository, RoleGroupRepository>(); services.AddSingleton<IActionRoleRepository, ActionRoleRepository>();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IRankRepository, RankRepository>();
            services.AddSingleton<IAuthenticationRepository, AuthenticationRepository>();
        }
        private static void InjectContext(IServiceCollection services)
        {
            services.AddSingleton<UserActionRoleRepository>(services => new UserActionRoleRepository(context));
            services.AddSingleton<RoleGroupRepository>(services => new RoleGroupRepository(context));
            services.AddSingleton<ActionRoleRepository>(services => new ActionRoleRepository(context));
            services.AddSingleton<UserRoleGroupRepository>(services => new UserRoleGroupRepository(context));
            services.AddSingleton<UserRepository>(services => new UserRepository(context));
            services.AddSingleton<RankRepository>(services => new RankRepository(context));
            services.AddSingleton<IDbContext, AuthenticationContext>();
            services.AddSingleton<AuthenticationRepository>(services => new AuthenticationRepository(context));
        }
    }
}