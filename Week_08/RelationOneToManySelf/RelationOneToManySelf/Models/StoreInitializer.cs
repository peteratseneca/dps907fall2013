using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// more...
using System.Data.Entity;

namespace RelationOneToManySelf.Models
{
    public class StoreInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            // Add initial objects to the store

            Employee marylynn = new Employee() { FirstName = "Mary Lynn", LastName = "Manton" };
            context.Employees.Add(marylynn);

            context.SaveChanges();

            // Notice the following code...
            // We assign the Employee object ('marylynn') to the ReportsToEmployee property 
            // We do not have to configure the ReportsToEmployeeId property
            // It gets auto-magically assigned

            Employee peter = new Employee() { FirstName = "Peter", LastName = "McIntyre", ReportsToEmployee = marylynn };
            context.Employees.Add(peter);

            Employee ian = new Employee() { FirstName = "Ian", LastName = "Tipson", ReportsToEmployee = marylynn };
            context.Employees.Add(ian);

            context.SaveChanges();

            // FYI - here's the code that creates the SQL Server database table...
            // (based on the Employee class definition)

            /*
            CREATE TABLE [dbo].[Employees] (
                [Id]                  INT            IDENTITY (1, 1) NOT NULL,
                [LastName]            NVARCHAR (MAX) NULL,
                [FirstName]           NVARCHAR (MAX) NULL,
                [ReportsToEmployeeId] INT            NULL,
                CONSTRAINT [PK_dbo.Employees] PRIMARY KEY CLUSTERED ([Id] ASC),
                CONSTRAINT [FK_dbo.Employees_dbo.Employees_ReportsToEmployeeId] FOREIGN KEY ([ReportsToEmployeeId]) REFERENCES [dbo].[Employees] ([Id])
            );
            */

        }
    }
}