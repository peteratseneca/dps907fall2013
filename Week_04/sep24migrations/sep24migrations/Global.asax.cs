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

namespace sep24migrations
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
            // Commented out, because we do NOT want the database re-initialized
            // if the model changes, because WE WANT TO KEEP THE DATA (in this code example)
            //System.Data.Entity.Database.SetInitializer(new Models.StoreInitializer());

            // AutoMapper definitions

            // Program - FROM app domain model classes
            Mapper.CreateMap<Models.Program, ViewModels.ProgramList>();
            Mapper.CreateMap<Models.Program, ViewModels.ProgramFull>();
            Mapper.CreateMap<Models.Program, ViewModels.ProgramWithSubjects>();

            // Program - TO app domain model classes
            Mapper.CreateMap<ViewModels.ProgramPublic, Models.Program>();
            Mapper.CreateMap<ViewModels.ProgramBase, Models.Program>();
            Mapper.CreateMap<ViewModels.ProgramFull, Models.Program>();

            // Subject - FROM app domain model classes
            Mapper.CreateMap<Models.Subject, ViewModels.SubjectList>();
            Mapper.CreateMap<Models.Subject, ViewModels.SubjectFull>();
            Mapper.CreateMap<Models.Subject, ViewModels.SubjectWithProgram>();

            // Subject - TO app domain model classes
            Mapper.CreateMap<ViewModels.SubjectPublic, Models.Subject>();
            Mapper.CreateMap<ViewModels.SubjectFull, Models.Subject>();
            Mapper.CreateMap<ViewModels.SubjectAdd, Models.Subject>();

        }

    }

}