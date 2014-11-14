using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RunChallenge.MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //
            //routes.Clear();

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Moderate Article",
            //    url: "moderations/{id}",
            //    defaults: new { controller = "Moderations", action = "Moderate" });

            routes.MapRoute(
                name: "Get articles by category",
                url: "articles/categorised/{category}",
                defaults: new { controller = "Articles", action = "GetByCategory" });

            routes.MapRoute(
                name: "Display Article",
                url: "articles/{id}/{url}",
                defaults: new { controller = "Articles", action = "Display" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "RunChallenge.MVC.Controllers" }
            );

            //routes.MapRoute(
            //    name: "StaticPages",
            //    url: "{action}",
            //    defaults: new { controller = "Home" }
            //    namespaces: new[] { "RunChallenge.MVC.Controllers" }
            //);
        }
    }
}
