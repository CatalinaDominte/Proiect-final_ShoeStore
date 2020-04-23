using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ShoeControl
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.Name;
        }

       Logger logger = LogManager.GetCurrentClassLogger();
        protected void Application_Error()
        {
            
            var ex = this.Server.GetLastError();
             logger.Error(ex);
        }
    }
}
