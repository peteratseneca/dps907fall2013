using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// more...
using System.Data.Entity;

namespace ExceptionFilter.Models
{
    public class StoreInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    //public class StoreInitializer : DropCreateDatabaseAlways<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            // Add initial objects to the store

            Album dsm = new Album() { Name = "Dark Side of the Moon", Artist = "Pink Floyd", YearReleased = 1973, Genre = "Rock" };
            context.Albums.Add(dsm);

            Album cmp = new Album() { Name = "Crash My Party", Artist = "Luke Bryan", YearReleased = 2013, Genre = "Country" };
            context.Albums.Add(cmp);

            context.SaveChanges();
        }
    }
}