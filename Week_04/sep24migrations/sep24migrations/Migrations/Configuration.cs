using sep24migrations.Models;

namespace sep24migrations.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<sep24migrations.Models.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(sep24migrations.Models.DataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            Program bsd = new Program() { Code = "BSD", Name = "Software Development", Credential = "Degree", DateCreated = new DateTime(2003, 9, 1), Description = "This program...", Semesters = 8 };
            context.Programs.AddOrUpdate(p => p.Id, bsd);

            Program cpa = new Program() { Code = "CPA", Name = "Computer Programming", Credential = "Diploma", DateCreated = new DateTime(1970, 9, 1), Description = "This program...", Semesters = 6 };
            context.Programs.AddOrUpdate(p => p.Id, cpa);

            Subject dps907 = new Subject() { Code = "DPS907", Name = "Web Services", Description = "This subject...", Program = bsd, DateCreated = DateTime.Now, Status = "Current" };
            context.Subjects.AddOrUpdate(s => s.Id, dps907);

            Subject wsa500 = new Subject() { Code = "WSA500", Name = "Web Services", Description = "This subject...", Program = cpa, DateCreated = DateTime.Now, Status = "Current" };
            context.Subjects.AddOrUpdate(s => s.Id, wsa500);

            context.SaveChanges();

        }
    }
}
