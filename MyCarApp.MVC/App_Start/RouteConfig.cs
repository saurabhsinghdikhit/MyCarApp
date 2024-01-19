using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyCarApp.MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            /*// making landing page default
            routes.MapRoute(
                "Default_route",
                "{controller}/{action}/{id}",
                new { area = "UserScreen", controller = "User", action = "LandingPage", id = UrlParameter.Optional }, // Parameter defaults
                null,
                new[] { "MVCProject.Site.Areas.UserScreen.Controllers" }
            ).DataTokens.Add("area", "UserScreen");*/
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "User", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
