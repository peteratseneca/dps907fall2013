using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// repositories need a reference to the app domain model classes
using sep24images.Models;

namespace sep24images.ViewModels
{
    public class RepositoryBase
    {
        // Declare the data context
        protected DataContext ds;

        // Initialize
        public RepositoryBase()
        {
            ds = new DataContext();

            // Turn off the Entity Framework (EF) proxy creation features
            // We do NOT want the EF to track changes - we'll do that ourselves
            ds.Configuration.ProxyCreationEnabled = false;

            // Also, turn off lazy loading...
            // We want to retain control over fetching related objects
            ds.Configuration.LazyLoadingEnabled = false;
        }
    }
}
