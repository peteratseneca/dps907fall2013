using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// more...
using System.ComponentModel.DataAnnotations;

#pragma warning disable 1591

namespace RelationOneToManySelf.Models
{
    // After adding classes, edit the DataContext class
    // If required, edit the StoreInitializer class

    public class Employee
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        // Include an int property to hold the identifier of the pointed-to object
        // It must be nullable, because it is optional (in most situations)
        public Nullable<int> ReportsToEmployeeId { get; set; }
        // Next, include a nav property to this class 
        public Employee ReportsToEmployee { get; set; }

        // Finally, include the 'other' side of the association
        // An employee who is a supervisor has a collection of employees
        // who report to the supervisor
        public ICollection<Employee> EmployeesSupervised { get; set; }
    }

}
