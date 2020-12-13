using Store.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using Microsoft.AspNetCore.Routing;

namespace Store.Web.Extentions
{
    public static class RouteBuilderExtentions
    {
        public static IRouteBuilder UseAppicationRoute(this IRouteBuilder routes)
        {
            routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");

            routes.MapRoute(
                name: "areaRoute",
                template: "{controller=Product}/{action=Detail}/{id?}");

            routes.MapRoute(
                    name: "areaRoute",
                    template: "{area:exists}/{controller=dashboard}/{action=index}/{id?}"
                );

            return routes;
        }

    }
}
