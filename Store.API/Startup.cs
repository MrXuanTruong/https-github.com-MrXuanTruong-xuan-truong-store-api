using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Store.API.Extentions;
using DataTables.AspNet.Core;
using DataTables.AspNet.AspNetCore;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;

namespace Store.API
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
            services.ConfigureCors();

            services.AddCustomOptions(Configuration);

            services.AddDependencyInjection();

            services.AddAutoMapper(this.GetType().Assembly);

            services.AddJwtBearerAuthenticate(Configuration);

            services.AddDatabaseContext(Configuration);

            services.AddDistributedMemoryCache();

            services.AddSwaggerExtensions();

            services.AddControllers().AddNewtonsoftJson();

            // DataTables.AspNet registration with default options.
            services.RegisterDataTables();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            loggerFactory.AddLog4Net();

            app.UseHttpsRedirection();

            app.UseCors("CorsPolicy");

            app.UseStaticFiles();

            app.UseSwaggerExtensions();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseUnitOfWorkMiddleware();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
