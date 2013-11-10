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
    public class AlbumsController : ApiController
    {
        Repo_Album r = new Repo_Album();

        // GET api/albums?nolinks
        // This was the kind of method we wrote before using link relations
        public IEnumerable<AlbumFull> Get(string nolinks)
        {
            // Get all
            return r.GetAll();
        }

        // GET api/albums
        public HttpResponseMessage Get()
        {
            // Get all
            var fetchedResults = r.GetAll();

            // Create an object to be returned
            AlbumsLinked albums = new AlbumsLinked();

            // Set its collection property
            albums.Collection = AutoMapper.Mapper.Map<IEnumerable<AlbumLink>>(fetchedResults);

            // Get the request URI path
            string self = Request.RequestUri.AbsolutePath;

            // Add a link relation for 'self'
            albums.Links.Add(new Link() { Rel = "self", Href = self });

            // Add a link relation for 'item' on each item in the collection
            foreach (var item in albums.Collection)
            {
                item.Link = new Link() { Rel = "item", Href = string.Format("{0}/{1}", self, item.Id) };
            }

            // Return the results
            return Request.CreateResponse<AlbumsLinked>(HttpStatusCode.OK, albums);
        }

        // GET api/albums/5?nolinks
        // This was the kind of method we wrote before using link relations
        public HttpResponseMessage Get(int id, string nolinks)
        {
            // Get one
            var fetchedResult = r.GetById(id);

            return (fetchedResult == null) ?
                Request.CreateResponse(HttpStatusCode.NotFound) :
                Request.CreateResponse<AlbumFull>(HttpStatusCode.OK, fetchedResult);
        }

        // GET api/albums/5
        public HttpResponseMessage Get(int id)
        {
            // Get one
            var fetchedResult = r.GetById(id);

            if (fetchedResult == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                // Create an object to be returned
                AlbumLinked album = new AlbumLinked();

                // Set its item property
                album.Item = AutoMapper.Mapper.Map<AlbumLink>(fetchedResult);

                // Get the request URI path
                string self = Request.RequestUri.AbsolutePath;

                // Add a link relation for 'self'
                album.Links.Add(new Link() { Rel = "self", Href = self });

                // Add a link relation for the parent 'collection'
                List<string> u = Request.RequestUri.Segments.ToList();
                album.Links.Add(new Link() { Rel = "collection", Href = u[0] + u[1] + u[2] });

                // Add a link relation for 'self' in the item 
                album.Item.Link = new Link() { Rel = "self", Href = self };

                // Return the result
                return Request.CreateResponse<AlbumLinked>(HttpStatusCode.OK, album);
            }
        }

        // POST api/albums
        public void Post([FromBody]string value)
        {
        }

        // PUT api/albums/5
        public void Put(int id, [FromBody]string value)
        {
        }

        /*
        // DELETE api/albums/5
        public void Delete(int id)
        {
        }
        */
    }
}
