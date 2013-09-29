using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// more...
using System.Data.Entity;
using System.Web.Hosting;
using System.IO;

namespace sep24images.Models
{
    // Notice the superclass
    public class StoreInitializer : DropCreateDatabaseIfModelChanges<DataContext> 
    {
        // Implement the Seed method, instead of a constructor
        protected override void Seed(DataContext context)
        {
            // Get the contents of a file as a byte array
            // Set it as a property for the new vehicle object

            Vehicle v = new Vehicle();
            v.Model = "Camry";
            v.Trim = "LE";
            v.Year = 2013;
            v.MSRP = 23700;
            v.ContentType = "image/png";
            v.Photo = File.ReadAllBytes(HostingEnvironment.MapPath("~/Assets/images/2013_camry_le.png"));
            context.Vehicles.Add(v);

            v = null;
            v = new Vehicle { Model = "Camry", Trim = "SE", Year = 2013, MSRP = 26985, ContentType = "image/png" };
            v.Photo = File.ReadAllBytes(HostingEnvironment.MapPath("~/Assets/images/2013_camry_se.png"));
            context.Vehicles.Add(v);

            v = null;
            v = new Vehicle { Model = "Camry", Trim = "SE V6", Year = 2013, MSRP = 29740, ContentType = "image/png" };
            v.Photo = File.ReadAllBytes(HostingEnvironment.MapPath("~/Assets/images/2013_camry_se_v6.png"));
            context.Vehicles.Add(v);

            v = null;
            v = new Vehicle { Model = "Camry", Trim = "XLE", Year = 2013, MSRP = 30470, ContentType = "image/png" };
            v.Photo = File.ReadAllBytes(HostingEnvironment.MapPath("~/Assets/images/2013_camry_xle.png"));
            context.Vehicles.Add(v);

            v = null;
            v = new Vehicle { Model = "Camry", Trim = "XLE V6", Year = 2013, MSRP = 34275, ContentType = "image/png" };
            v.Photo = File.ReadAllBytes(HostingEnvironment.MapPath("~/Assets/images/2013_camry_xle_v6.png"));
            context.Vehicles.Add(v);

            context.SaveChanges();
        }
    }
}