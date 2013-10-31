using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// more
using System.Data.Entity;

namespace RelationOneToManySelf.Models
{
    public class DataContext : DbContext
    {
        public DataContext() : base("name=DataContext") { }

        public DbSet<Employee> Employees { get; set; }
    }
}
