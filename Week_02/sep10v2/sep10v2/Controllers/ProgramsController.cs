using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace sep10v2.Controllers
{
    public class ProgramsController : ApiController
    {
        // Create a reference to the data service
        private DataService ds = new DataService();

        // GET api/programs
        public IEnumerable<string> Get()
        {
            return ds.AllPrograms();
        }

        // GET api/programs/5
        public string Get(int id)
        {
            return "not implemented";
        }

        // POST api/programs
        public void Post([FromBody]string value)
        {
        }

        // PUT api/programs/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/programs/5
        public void Delete(int id)
        {
        }
    }
}
