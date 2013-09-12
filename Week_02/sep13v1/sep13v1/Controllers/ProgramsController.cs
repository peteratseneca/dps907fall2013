using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
// more...
using sep13v1.ViewModels;

namespace sep13v1.Controllers
{
    public class ProgramsController : ApiController
    {
        // Create a reference to the repository (the 'new' data service)
        private Repo_Program r = new Repo_Program();

        // Methods in this controller class can see the view model classes
        // However, they CANNOT see the app domain model classes

        // GET api/programs
        public IEnumerable<ProgramFull> Get()
        {
            return r.GetAll();
        }

        // GET api/programs/5
        public ProgramFull Get(int id)
        {
            var program = r.GetById(id);
            return (program == null) ? null : program;
        }

        // POST api/programs
        public void Post([FromBody]string value)
        {
            // not yet implemented
        }

        // PUT api/programs/5
        public void Put(int id, [FromBody]string value)
        {
            // not yet implemented
        }

        // DELETE api/programs/5
        public void Delete(int id)
        {
            // not yet implemented
        }
    }
}
