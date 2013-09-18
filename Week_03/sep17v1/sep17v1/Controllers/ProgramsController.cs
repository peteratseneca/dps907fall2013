﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
// more...
using sep17v1.ViewModels;

namespace sep17v1.Controllers
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

        // GET api/programs?list
        // The runtime looks for a query string key "list"
        public IEnumerable<ProgramList> Get(string list)
        {
            return r.GetList();
        }

        // GET api/programs/5
        public HttpResponseMessage Get(int id)
        {
            var program = r.GetById(id);

            return (program == null) ?
                Request.CreateResponse(HttpStatusCode.NotFound) :
                Request.CreateResponse<ProgramFull>(HttpStatusCode.OK, program);
        }

        // POST api/programs
        public HttpResponseMessage Post(ProgramPublic newProgram)
        {
            if (ModelState.IsValid)
            {
                // Add the new program
                var p = r.AddNew(newProgram);

                // Build the response object
                var response = Request.CreateResponse<ProgramFull>(HttpStatusCode.Created, p);

                // Set the Location header
                // The "new Uri" object constructor needs a string argument
                // The ApiController.Url property provides that 
                // Its Link() method takes two arguments...
                // A route name, which can be seen in App_Start/WebApiConfig.cs, and 
                // A route value, which substitutes for the {id} placeholder
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = p.Id }));

                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.UnsupportedMediaType);
            }
        }

        // PUT api/programs/5
        public HttpResponseMessage Put(int id, ProgramBase updatedProgram)
        {
            if (ModelState.IsValid & id == updatedProgram.Id)
            {
                // Update the existing program
                var p = r.UpdateExisting(updatedProgram);

                if (p == null)
                {
                    // If we cannot update the object for some reason
                    // Not sure if this is the best response
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
                else
                {
                    // Return the updated object
                    return Request.CreateResponse<ProgramFull>(HttpStatusCode.OK, p);
                }
            }
            else
            {
                // Not sure if this is the best response
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/programs/5
        public void Delete(int id)
        {
            // In a controller 'Delete' method, a void return type
            // automatically generates a "204 No content" HTTP status code
            r.DeleteExisting(id);
        }

    }

}
