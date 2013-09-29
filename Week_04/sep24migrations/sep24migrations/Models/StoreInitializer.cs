using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// more...
using System.Data.Entity;

namespace sep24migrations.Models
{
    // Notice the superclass
    public class StoreInitializer : DropCreateDatabaseIfModelChanges<DataContext> 
    {
        // Implement the Seed method, instead of a constructor
        protected override void Seed(DataContext context)
        {
            // Build the data normally, then save
            // Tip - use meaningful (semantic) names for your variables

            Program bsd = new Program() { Code = "BSD", Name = "Software Development", Credential = "Degree", DateCreated = new DateTime(2003, 9, 1), Description = "This program...", Semesters = 8 };
            context.Programs.Add(bsd);

            Program cpa = new Program() { Code = "CPA", Name = "Computer Programming", Credential = "Diploma", DateCreated = new DateTime(1970, 9, 1), Description = "This program...", Semesters = 6 };
            context.Programs.Add(cpa);

            Subject dps907 = new Subject() { Code = "DPS907", Name = "Web Services", Description = "This subject...", Program = bsd };
            context.Subjects.Add(dps907);

            Subject wsa500 = new Subject() { Code = "WSA500", Name = "Web Services", Description = "This subject...", Program = cpa };
            context.Subjects.Add(wsa500);

            context.SaveChanges();
        }
    }
}