using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
// more...
using sep24migrations.ViewModels;

namespace sep24migrations.Controllers
{
    public class SubjectsController : ApiController
    {
        // Create a reference to the repository (the 'new' data service)
        private Repo_Subject r = new Repo_Subject();

        // Methods in this controller class can see the view model classes
        // However, they CANNOT see the app domain model classes

        // GET api/subjects
        /// <summary>
        /// All subjects, sorted by subject code
        /// </summary>
        /// <returns>Collection of Subject objects</returns>
        public IEnumerable<SubjectFull> Get()
        {
            return r.GetAll();
        }

        // GET api/subjects?list
        // The runtime looks for a query string key "list"
        /// <summary>
        /// All subjects, for a lookup list
        /// </summary>
        /// <param name="list">Add the query string 'list'</param>
        /// <returns>Collection of Subject objects, suitable for use in a lookup list</returns>
        public IEnumerable<SubjectList> Get(string list)
        {
            return r.GetList();
        }

        // GET api/subjects/5
        /// <summary>
        /// One subject, by its identifier
        /// </summary>
        /// <param name="id">Subject object identifier</param>
        /// <returns>One Subject object</returns>
        public HttpResponseMessage Get(int id)
        {
            var subject = r.GetById(id);

            return (subject == null) ?
                Request.CreateResponse(HttpStatusCode.NotFound) :
                Request.CreateResponse<SubjectFull>(HttpStatusCode.OK, subject);
        }

        // GET api/subjects/5?program
        /// <summary>
        /// One subject, by its identifier; includes its program information
        /// </summary>
        /// <param name="id">Subject object identifier</param>
        /// <param name="program">Add a query string 'program'</param>
        /// <returns>One Subject object, with associated Program information</returns>
        public HttpResponseMessage GetWithProgram(int id, string program)
        {
            var subject = r.GetByIdWithProgram(id);

            return (subject == null) ?
                Request.CreateResponse(HttpStatusCode.NotFound) :
                Request.CreateResponse<SubjectWithProgram>(HttpStatusCode.OK, subject);
        }

        // POST api/subjects
        // Notice that we're using the SubjectAdd type in this method
        // We need a Program Id in the message body
        /// <summary>
        /// Add a new Subject object to the collection
        /// </summary>
        /// <param name="newSubject">Fully-configured Subject object, with its program identifier</param>
        /// <returns>Fully-configured new Subject object</returns>
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
        /// <summary>
        /// Update an existing Subject object, by its identifier
        /// </summary>
        /// <param name="id">Subject object identifier</param>
        /// <param name="updatedSubject">Updated Subject object in the message body</param>
        /// <returns>Updated Subject object</returns>
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
        /// <summary>
        /// Delete an existing Subject object
        /// </summary>
        /// <param name="id">Subject object identifier</param>
        public void Delete(int id)
        {
            // In a controller 'Delete' method, a void return type
            // automatically generates a "204 No content" HTTP status code
            r.DeleteExisting(id);
        }

    }

}
