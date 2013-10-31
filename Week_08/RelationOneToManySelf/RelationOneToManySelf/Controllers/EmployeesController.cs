using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
// more...
using RelationOneToManySelf.Models;

namespace RelationOneToManySelf.Controllers
{
    public class EmployeesController : ApiController
    {
        // GET api/employees
        public IEnumerable<string> Get()
        {
            // For this code example, I didn't need a view model or repository
            // This is a quick way to get content out of a controller method
            using (var ds = new DataContext())
            {
                List<string> employees = new List<string>();

                // On your own, try running this without the 'Include()' methods
                var allEmps = ds.Employees
                    .Include("EmployeesSupervised")
                    .Include("ReportsToEmployee");

                // Generate the results
                foreach (var item in allEmps)
                {
                    employees.Add(string.Format("{0} {1}, id {2}, reports to id {3} ({4}), supervises {5} ({6})",
                        item.FirstName,
                        item.LastName,
                        item.Id.ToString(),
                        item.ReportsToEmployeeId.GetValueOrDefault().ToString(),
                        ((item.ReportsToEmployee == null) ? "no one" : item.ReportsToEmployee.LastName),
                        item.EmployeesSupervised.Count.ToString(),
                        string.Join(", ", item.EmployeesSupervised.Select(n => n.LastName).ToArray())
                        ));
                }

                return employees;
            }
        }

        /*
        // GET api/employees/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/employees
        public void Post([FromBody]string value)
        {
        }

        // PUT api/employees/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/employees/5
        public void Delete(int id)
        {
        }
        */
    }
}
