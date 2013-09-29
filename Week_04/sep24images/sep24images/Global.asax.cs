using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
// more...
using AutoMapper;

namespace sep24images
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

            // Data store initializer
            System.Data.Entity.Database.SetInitializer(new Models.StoreInitializer());

            // Image media type formatter
            GlobalConfiguration.Configuration.Formatters.Add(new sep24images.Formatters.ImageFormatter());

            // AutoMapper definitions

            // Program - FROM app domain model classes
            Mapper.CreateMap<Models.Vehicle, ViewModels.VehiclePublic>();
            Mapper.CreateMap<Models.Vehicle, ViewModels.VehicleBase>();
            Mapper.CreateMap<Models.Vehicle, ViewModels.VehicleFull>();

            // Program - TO app domain model classes
            Mapper.CreateMap<ViewModels.VehiclePublic, Models.Vehicle>();
            Mapper.CreateMap<ViewModels.VehicleBase, Models.Vehicle>();
            Mapper.CreateMap<ViewModels.VehicleFull, Models.Vehicle>();

        }

    }

}