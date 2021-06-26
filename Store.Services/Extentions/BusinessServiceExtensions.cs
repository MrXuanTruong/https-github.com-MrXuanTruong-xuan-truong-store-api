using Microsoft.Extensions.DependencyInjection;
using Store.Services.EmailServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Services.Extentions
{
    public static class BusinessServiceExtensions
    {
        public static void AddDependencyInjectionForService(this IServiceCollection services)
        {
            services.AddScoped<IEmailService, EmailService>();

            // Register services
            var assembly = typeof(BusinessServiceExtensions).Assembly;
            services.AddScopedByConvention(assembly, x => x.Name.EndsWith("Service") && !x.Name.EndsWith("BaseService"));
        }
    }
}
