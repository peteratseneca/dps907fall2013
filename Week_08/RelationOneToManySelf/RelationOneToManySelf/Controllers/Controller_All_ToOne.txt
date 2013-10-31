using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
// more...
using sep20v1.ViewModels;

namespace sep20v1.Controllers
{
    public class SubjectsController : ApiController
    {
        // Create a reference to the repository (the 'new' data service)
        private Repo_Subject r = new Repo_Subject();

        // Methods in this controller class can see the view model classes
        // However, they CANNOT see the app domain model classes

        // GET api/subjects
        public IEnumerable<SubjectFull> Get()
        {
            return r.GetAll();
        }

        // GET api/subjects?list
        // The runtime looks for a query string key "list"
        public IEnumerable<SubjectList> Get(string list)
        {
            return r.GetList();
        }

        // GET api/subjects/5
        public HttpResponseMessage Get(int id)
        {
            var subject = r.GetById(id);

            return (subject == null) ?
                Request.CreateResponse(HttpStatusCode.NotFound) :
                Request.CreateResponse<SubjectFull>(HttpStatusCode.OK, subject);
        }

        // GET api/subjects/5?program
        public HttpResponseMessage GetWithProgram(int id, string program)
        {
            var subject = r.GetByIdWithProgram(id);

            return (subject == null) ?
                Request.CreateResponse(HttpStatusCode.NotFound) :
                Request.CreateResponse<SubjectWithProgram>(HttpStatusCode.OK, subject);
        }

        // POST api/subjects
        // Notice that we're using the SubjectAdd type in this method
        // We need a Program Id
        public HttpResponseMessage Post(SubjectAdd newSubject)
        {
            if (ModelState.IsValid)
            {
                // Add the new program
                var s = r.AddNew(newSubject);

                // Make sure that we can continue
                if (s == null)
                {
                    // We probably need a better status code...
                    return Request.CreateResponse(HttpStatusCode.UnsupportedMediaType);
                }
                else
                {
                    // Build the response object
                    var response = Request.CreateResponse<SubjectFull>(HttpStatusCode.Created, s);

                    // Set the Location header
                    // The "new Uri" object constructor needs a string argument
                    // The ApiController.Url property provides that 
                    // Its Link() method takes two arguments...
                    // A route name, which can be seen in App_Start/WebApiConfig.cs, and 
                    // A route value, which substitutes for the {id} placeholder
                    response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = s.Id }));

                    return response;
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.UnsupportedMediaType);
            }
        }

        // PUT api/subjects/5
        // Notice that we're using the SubjectFull type here
        // We will NOT permit the user to change the Program Id in a PUT request
        // (later, we'll build a command workflow to handle that need)
        public HttpResponseMessage Put(int id, SubjectFull updatedSubject)
        {
            if (ModelState.IsValid & id == updatedSubject.Id)
            {
                // Update the existing program
                var s = r.UpdateExisting(updatedSubject);

                if (s == null)
                {
                    // If we cannot update the object for some reason
                    // Not sure if this is the best response
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
                else
                {
                    // Return the updated object
                    return Request.CreateResponse<SubjectFull>(HttpStatusCode.OK, s);
                }
            }
            else
            {
                // Not sure if this is the best response
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/subjects/5
        public void Delete(int id)
        {
            // In a controller 'Delete' method, a void return type
            // automatically generates a "204 No content" HTTP status code
            r.DeleteExisting(id);
        }

    }

}
