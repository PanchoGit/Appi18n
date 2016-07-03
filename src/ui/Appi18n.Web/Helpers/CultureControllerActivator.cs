using System;
using System.Globalization;
using System.Threading;
using System.Web.Mvc;
using System.Web.Routing;

namespace Appi18n.Web.Helpers
{
    public class CultureControllerActivator : IControllerActivator
    {
        public IController Create(RequestContext requestContext, Type controllerType)
        {
            var language = (string)requestContext.RouteData.Values["language"] ?? "fr";
            var culture = (string)requestContext.RouteData.Values["culture"] ?? "FR";

            var cultureInfo = CultureInfo.GetCultureInfo(string.Format("{0}-{1}", language, culture));

            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;

            return DependencyResolver.Current.GetService(controllerType) as IController;
        }
    }
}