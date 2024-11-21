using JwtAuthenticationManager;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Operation_FinanceManagement.Context;
using Operation_FinanceManagement.Injector;
namespace Operation_FinanceManagement
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
            services.AddCors();
            //services.AddHealthChecks();
            services.AddDbContext<FinanceManagementContext>(options => options.UseSqlServer(connectionString), ServiceLifetime.Singleton);
            Injector.Injector.Inject(services);
            services.AddSingleton<JwtTokenHandler>();
            services.AddCustomJwtAuthentication();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Operation_FinanceManagement", Version = "v1" });
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
            app.UseCors(
               options => options.AllowAnyOrigin().WithOrigins(
                 "http://localhost:44314"
               ).AllowAnyHeader().AllowAnyMethod()
               );
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Operation_FinanceManagement"));
            }
            else
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Operation_FinanceManagement"));
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