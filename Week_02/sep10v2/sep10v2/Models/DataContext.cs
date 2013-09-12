using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// more...
using System.Data.Entity;

namespace sep10v2.Models
{
    // Notice the superclass
    public class DataContext : DbContext
    {
        // The constructor for the base class (DbContext) is called
        // before this constructor's block is executed 
        // The data in parentheses is passed to the base class constructor
        public DataContext() : base("name=DataContext") {}

        // DbSet objects
        public DbSet<Program> Programs { get; set; }
        public DbSet<Subject> Subjects { get; set; }
    }
}
