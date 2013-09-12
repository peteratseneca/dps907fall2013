using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// more...
using sep10v2.Models;

namespace sep10v2.Controllers
{
    public class DataService
    {
        private DataContext dc = new DataContext();

        // September 10 version 2 example...
        // A work-in-progress, we'll output a simple string collection
        // This mimics the example from last week where we used simple strings

        public IEnumerable<string> AllPrograms()
        {
            // Create a  generic list collection to hold the Program name strings
            List<string> programs = new List<string>();

            // Go through the collection... add a Program name to the generic list
            foreach (var program in dc.Programs)
            {
                programs.Add(program.Name);
            }
            // Return the results to the caller
            return programs;
        }

    }
}
