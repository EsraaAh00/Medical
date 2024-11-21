using JwtAuthenticationManager;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System_Authentication.Context;
using System_Authentication.Entities;
using System_Authentication.Injector;
using SharedModels.Helpers;

namespace System_Authentication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("AppConnectionStrings");
           // services.AddCors();

            //services.AddHealthChecks();

            services.AddDbContext<AuthenticationContext>(options => options.UseSqlServer(connectionString), ServiceLifetime.Singleton);


            services.AddIdentity<User, RoleGroup>()
                              .AddEntityFrameworkStores<AuthenticationContext>()
                              .AddDefaultTokenProviders()
                              .AddSignInManager<SignInManager<User>>();

            Injector.Injector.Inject(services);
            DicHelper.Init();
            services.AddSingleton<JwtTokenHandler>();
            services.AddCustomJwtAuthentication();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Authentication", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            var builder = new ConfigurationBuilder()


         .SetBasePath(env.ContentRootPath)
         .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
         .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
         .AddEnvironmentVariables();

            /* app.Use((context, next) =>
             {
                 var request = context.Request;
                 BaseHttpContext.Token = request?.Headers["Authorization"] ?? "";
                 BaseHttpContext.Lang = request?.Headers["Accept-Language"] ?? "";
                 //CultureHelper.SetLanguage(Lang);
                 return next.Invoke();
             });*/



            app.UseCors(options => options.AllowAnyOrigin().WithOrigins().AllowAnyHeader().AllowAnyMethod());

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Authentication v1"));
            }
            else
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Authentication v1"));
            }


            app.UseHttpsRedirection();
            app.UseDeveloperExceptionPage();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }



    }
}
