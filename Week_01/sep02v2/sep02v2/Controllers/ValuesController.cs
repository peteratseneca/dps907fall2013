using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace sep02v2.Controllers
{
    public class ValuesController : ApiController
    {
        // Data for this controller...
        // Created in-memory; the data will not be persisted
        List<string> colours = new List<string>() { "red", "green", "blue", "yellow", "orange", "brown" };

        // GET api/values
        public IEnumerable<string> Get()
        {
            return colours;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return colours[id];
        }

        // POST api/values
        public IEnumerable<string> Post([FromBody]string value)
        {
            colours.Add(value);
            return colours;
        }

        // PUT api/values/5
        public IEnumerable<string> Put(int id, [FromBody]string value)
        {
            colours[id] = value;
            return colours;
        }

        // DELETE api/values/5
        public IEnumerable<string> Delete(int id)
        {
            colours.RemoveAt(id);
            return colours;
        }
    }
}