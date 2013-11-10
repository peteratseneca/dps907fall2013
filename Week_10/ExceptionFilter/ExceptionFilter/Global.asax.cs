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

namespace ExceptionFilter
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
            GlobalConfiguration.Configuration.Formatters.Add(new Formatters.ImageFormatter());

            // Authentication handler
            GlobalConfiguration.Configuration.MessageHandlers.Add(new Handlers.OAuth2MessageHandler());

            // HTTP OPTIONS method handler
            GlobalConfiguration.Configuration.MessageHandlers.Add(new Handlers.HttpOptionsMethodHandler());

            // Exception filter
            GlobalConfiguration.Configuration.Filters.Add(new Handlers.ExceptionHandler());

            // AutoMapper definitions

            // 'Album' entity, to-and-from
            Mapper.CreateMap<ViewModels.AlbumAdd, Models.Album>();
            Mapper.CreateMap<Models.Album, ViewModels.AlbumFull>();
            Mapper.CreateMap<ViewModels.AlbumFull, ViewModels.AlbumLink>();

            // 'LoggedException' entity, to-and-from
            Mapper.CreateMap<ViewModels.LoggedExceptionAdd, Models.LoggedException>();
            Mapper.CreateMap<Models.LoggedException, ViewModels.LoggedExceptionFull>();

        }
    }
}