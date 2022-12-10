using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MVC_CV
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            GlobalFilters.Filters.Add(new AuthorizeAttribute()); //Adding authorize attribute to all pages so that all the pages are restricted where access is not authorized.


            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
