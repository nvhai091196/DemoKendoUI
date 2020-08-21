using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace WebApiStudy.Presentation.Filters
{
    public class CultureAwareControllerActivator : IControllerActivator
    {
        public IController Create(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            string curltureName = "vi";
            CultureInfo culture = new CultureInfo(curltureName)
            {
                DateTimeFormat = {
                    ShortDatePattern = "dd/MM/yyyy"
                        },
            };
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            return DependencyResolver.Current.GetService(controllerType) as IController;
        }
    }
}