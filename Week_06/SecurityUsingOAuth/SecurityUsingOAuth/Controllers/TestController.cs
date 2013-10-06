using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SecurityUsingOAuth.Controllers
{
    // You can use the "TestController" to test different security scenarios
    // Create at least two credentials (using POST to ~api/credentials)
    // Configure one to be in a "User" role, and the other in an "Admin" role 
    // Then, change the config of the class and/or its methods to test your work
    // [Authorize]
    // [Authorize(Roles = "Member")]
    // [Authorize(Users = "yourname")]
    // [Authorize(Roles = "Administrator,Member", Users = "yourname")]
    // etc.

    public class TestController : ApiController
    {
        // GET api/test
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/test?info
        public string GetInfo(string info)
        {
            return string.Format("{0} | {1} | {2} | {3}",
                User.Identity.IsAuthenticated ? "Authenticated" : "Not logged in",
                string.IsNullOrEmpty(User.Identity.Name) ? "No user name" : User.Identity.Name,
                User.IsInRole("Administrator") ? "An administrator" : "Not an administrator",
                User.IsInRole("Member") ? "Member" : "Not a member");
        }

        [Authorize(Roles = "Member")]
        // GET api/test/5
        public string Get(int id)
        {
            return User.Identity.Name;
        }

        // POST api/test
        public void Post([FromBody]string value)
        {
        }

        // PUT api/test/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/test/5
        public void Delete(int id)
        {
        }
    }
}
