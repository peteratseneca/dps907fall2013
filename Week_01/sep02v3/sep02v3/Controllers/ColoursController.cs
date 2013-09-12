using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace sep02v3.Controllers
{
    public class ColoursController : ApiController
    {
        DataService ds = new DataService();

        // GET api/colours
        public IEnumerable<string> Get()
        {
            return ds.GetColourNames();
        }

        // GET api/colours/5
        public string Get(int id)
        {
            return ds.GetColourById(id);
        }

        // POST api/colours
        public string Post([FromBody]string value)
        {
            return ds.AddColour(value);
        }

        // PUT api/colours/5
        public void Put(int id, [FromBody]string value)
        {
            // Not implemented
        }

        // DELETE api/colours/5
        public void Delete(int id)
        {
            // Not implemented
        }
    }
}
