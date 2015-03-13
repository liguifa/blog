using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Blog
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
              name: "html",
              url: "{controller}/{action}.html",
              defaults: new { controller = "Home", action = "Index" }
          );

            routes.MapRoute(
               name: "paraesHtml",
               url: "{controller}/{action}/{type}/{num}.html",
               defaults: new { controller = "Home", action = "Content", type = UrlParameter.Optional, num = UrlParameter.Optional }
           );



            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
           );

            routes.MapRoute(
   name: "contetn",
   url: "{controller}/{action}/{type}/{num}",
   defaults: new { controller = "Home", action = "Content", type = UrlParameter.Optional, num = UrlParameter.Optional }
);
        }
    }
}