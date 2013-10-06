using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
// more...
using SecurityUsingOAuth.ViewModels;

namespace SecurityUsingOAuth.Controllers
{
    public class CredentialsController : ApiController
    {
        // Declare and initialize the repository
        private Repo_Credential r = new Repo_Credential();

        // GET api/credentials
        public IEnumerable<CredentialFull> Get()
        {
            return r.GetCredentials();
        }

        // GET api/credentials/5
        public HttpResponseMessage Get(int id)
        {
            CredentialFull c = r.GetCredentialById(id);
            return (c == null) ?
                Request.CreateResponse(HttpStatusCode.NotFound) :
                Request.CreateResponse<CredentialFull>(HttpStatusCode.OK, c);
        }

        // POST api/credentials
        public HttpResponseMessage Post(CredentialAdd credential)
        {
            if (ModelState.IsValid)
            {
                // Add the new credential
                CredentialFull c = r.AddCredential(credential);

                // Prepare the response
                HttpResponseMessage response =
                    Request.CreateResponse<CredentialFull>(HttpStatusCode.Created, c);
                // Add a Location header
                response.Headers.Location =
                    new Uri(Url.Link("DefaultApi", new { id = c.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.UnsupportedMediaType);
            }
        }

        // PUT api/credentials/5
        public void Put(int id, [FromBody]string value)
        {
            // not implemented
        }

        // DELETE api/credentials/5
        public void Delete(int id)
        {
            // not implemented
        }

    }
}
