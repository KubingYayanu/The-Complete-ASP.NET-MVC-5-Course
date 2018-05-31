using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            // for Facebook OAuth
            // default return_uri is "https://domain/signin-facebook"
            //routes.MapRoute(
            //    name: "signin-facebook",
            //    url: "sign-facebook",
            //    defaults: new { controller = "Account", action = "ExternalLoginCallback" });

            // for Google OAuth
            // default return_uri is "https://domain/sign-google"
            //routes.MapRoute(
            //    name: "sign-google",
            //    url: "sign-google",
            //    defaults: new { controller = "Account", action = "ExternalLoginCallback" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
