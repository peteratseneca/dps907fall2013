using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
// more
using oct01securitybasic.ViewModels;

namespace oct01securitybasic.Controllers
{
    public class VehiclesController : ApiController
    {
        Repo_Vehicle r = new Repo_Vehicle();

        // GET api/vehicles
        public IEnumerable<VehicleBase> Get()
        {
            return r.GetAll();
        }

        // GET api/vehicles/5
        public HttpResponseMessage Get(int id)
        {
            var v = r.GetById(id);

            // HTTP 404 if the vehicle doesn't exist, or it doesn't have a photo
            if (v == null | v.Photo.Length < 1)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                var response = Request.CreateResponse(HttpStatusCode.OK, v);

                // The repository method has returned a VehicleFull object 
                // We need to know if the request asked for an image to be returned.
                // If so, we need to configure the Content-Type header BEFORE the object
                // is passed on to the 'image' media formatter.
                // Unfortunately, the current design of the media formatter does not
                // allow us to dynamically set the response's Content-Type header.
                // See this post - http://stackoverflow.com/a/12565530 

                // Step 1 - look for an Accept header that starts with 'image'
                var imageHeader = Request.Headers.Accept
                    .SingleOrDefault(a => a.MediaType.ToLower().StartsWith("image"));
                // Step 2 - if found, set the Content-Type header value
                if (imageHeader != null)
                {
                    response.Content.Headers.ContentType =
                        new System.Net.Http.Headers.MediaTypeHeaderValue(v.ContentType);
                }

                return response;
            }
        }

        // POST api/vehicles
        public HttpResponseMessage Post(VehiclePublic vehicle)
        {
            if (ModelState.IsValid)
            {
                // Add the new object
                var v = r.AddNew(vehicle);

                // Build the response object
                var response = Request.CreateResponse<VehicleFull>(HttpStatusCode.Created, v);

                // Set the Location header
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = v.Id }));

                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.UnsupportedMediaType);
            }
        }

        // PUT api/vehicles/5
        public void Put(int id, [FromBody]string value)
        {
            // Provide your own implementation
        }

        // PUT api/vehicles/5?photo
        public HttpResponseMessage PutPhoto(int id, string photo, byte[] photoBytes)
        {
            // Notice the special URI with a query string

            // Update the existing object...

            // Get the Content-Type header from the request
            var contentType = Request.Content.Headers.ContentType.MediaType;

            // Call the repository method
            var v = r.UpdateExistingPhoto(id, contentType, photoBytes);

            if (v == null)
            {
                // If we cannot update the object for some reason
                // Not sure if this is the best response
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            else
            {
                // Return the updated object
                return Request.CreateResponse<VehicleFull>(HttpStatusCode.OK, v);
            }
        }

        // DELETE api/vehicles/5
        public void Delete(int id)
        {
            // Provide your own implementation
        }
    }
}
