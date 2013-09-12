using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace sep02v3
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Initialize the data for the app
            Models.StoreInitializer si = new Models.StoreInitializer();

            // Save the data in the "application state" object
            // MSDN - http://msdn.microsoft.com/en-us/library/ms178594(v=VS.100).aspx
            // The data will exist during the application's lifetime,
            // which is at least twenty minutes
            Application["Colours"] = si.Colours;
        }
    }
}