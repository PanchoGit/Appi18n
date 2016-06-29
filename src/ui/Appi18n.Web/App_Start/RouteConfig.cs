using System.Web.Mvc;
using System.Web.Routing;

namespace Appi18n.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "API",
                "api/{controller}/{action}/{id}",
                new { controller = "Note", action = "Index", id = UrlParameter.Optional }
                );

            routes.MapRoute(
                "Default",
                "{*catchall}",
                new { controller = "Home", action = "Index" }
            );
        }
    }
}
