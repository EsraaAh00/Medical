using JwtAuthenticationManager;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Vendor_ListingManagement.Context;
using Vendor_ListingManagement.Injector;
namespace Vendor_ListingManagement
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
            services.AddDbContext<ListingManagementContext>(options => options.UseSqlServer(connectionString), ServiceLifetime.Singleton);
            Injector.Injector.Inject(services);
            services.AddSingleton<JwtTokenHandler>();
            services.AddCustomJwtAuthentication();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "VendorListingManagement", Version = "v1" });
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
            app.UseCors(options =>
                options.AllowAnyOrigin()
                       .AllowAnyHeader()
                       .AllowAnyMethod());

            app.UseCors(options => options.AllowAnyOrigin().WithOrigins().AllowAnyHeader().AllowAnyMethod());

            app.UseCors(options => options.AllowAnyOrigin().WithOrigins().AllowAnyHeader().AllowAnyMethod());

            app.UseCors(options => options.AllowAnyOrigin().WithOrigins().AllowAnyHeader().AllowAnyMethod());

            app.UseCors(options => options.AllowAnyOrigin().WithOrigins().AllowAnyHeader().AllowAnyMethod());

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "VendorListingManagement"));
            }
            else
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "VendorListingManagement"));
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