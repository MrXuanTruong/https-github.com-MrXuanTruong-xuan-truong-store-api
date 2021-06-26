using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using Store.API.Services;
using Store.Entity;
using Store.Services.EmailServices;
using Store.Services.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.API.Extentions
{
    public static class ServiceExtensions
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            services.AddDependencyInjectionForService();
            services.TryAddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IViewRenderService, ViewRenderService>();
        }

        public static void AddCustomOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailServiceOptions>(configuration.GetSection("AppSettings:SMTPSettings"));
        }

        public static void AddDatabaseContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DatabaseContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<DatabaseContext>();
        }

        /// <summary>
        /// Posts: https://jasonwatmore.com/post/2018/08/14/aspnet-core-21-jwt-authentication-tutorial-with-example-api
        /// </summary>
        /// <param name="services"></param>
        public static void AddJwtBearerAuthenticate(this IServiceCollection services, IConfiguration configuration)
        {
            // configure strongly typed settings objects
            var secret = configuration.GetValue<string>("AppSettings:JWTSecret");
            var key = Encoding.ASCII.GetBytes(secret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });
        }

        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder =>
                    builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }
    }
}
