using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
// more...
using ExceptionFilter.ViewModels;

namespace ExceptionFilter.Controllers
{
    public class ErrorsController : ApiController
    {
        Repo_LoggedException r = new Repo_LoggedException();

        // GET api/errors
        /// <summary>
        /// Fetch all logged exception objects
        /// </summary>
        /// <returns>Collection of logged exception objects, sorted, most recent to oldest</returns>
        public IEnumerable<LoggedExceptionFull> Get()
        {
            return r.GetAll();
        }

        // GET api/errors?causeerror
        /// <summary>
        /// Cause an exception to happen
        /// </summary>
        /// <param name="causeerror">Add a query string 'causerror'</param>
        /// <returns>Doesn't return from this method; the exception filter handles the situation</returns>
        public string GetError(string causeerror)
        {
            // Cause an error...
            string foo = null;
            return foo.Length.ToString();
        }

        // GET api/errors/5
        /// <summary>
        /// Fetch a specific logged exception object by its identifier
        /// </summary>
        /// <param name="id">Logged exception identifier</param>
        /// <returns>A logged exception object</returns>
        public HttpResponseMessage Get(int id)
        {
            var fetchedResult = r.GetById(id);

            return (fetchedResult == null) ?
                Request.CreateResponse(HttpStatusCode.NotFound) :
                Request.CreateResponse<LoggedExceptionFull>(HttpStatusCode.OK, fetchedResult);
        }

    }
}
