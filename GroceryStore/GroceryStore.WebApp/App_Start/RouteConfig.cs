using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GroceryStore.WebApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               null,
               "",
               new 
               { 
                   Controller = "Product", 
                   action = "List",
               category = (string)null,
               oage = 1
               }
               );

            routes.MapRoute(
                null,
                "Page{page}",
                new { controller = "Product", action = "List", category = (string)null },
                new {page = @"\d+"}
            );

            routes.MapRoute(
                null,
                "{category}",
                new { controller = "Product", action = "list", page = 1 }
                );

            routes.MapRoute(
                null,
                "{category}/Page{page}",
                new { controller = "Product", action = "list" },
                new { page = @"\d+" }
                );

            routes.MapRoute(null, "{controller}/{action}");

           
        }
    }
}
