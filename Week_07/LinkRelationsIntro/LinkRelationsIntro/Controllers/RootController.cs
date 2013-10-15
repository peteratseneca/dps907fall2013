using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
// more...
using LinkRelationsIntro.ViewModels;

namespace LinkRelationsIntro.Controllers
{
    public class RootController : ApiController
    {
        // This controller answers a URI that ends with 'api'
        // It's intended to handle requests to the 'root' URI
        // Eventually, it will return a collection of link relations

        // This controller is called because we added a default value for 'controller'
        // in the App_Start > WebApiConfig class

        // GET api/root, or just '/api' (or '/api/')
        public IDictionary<string, List<Link>> GetMore()
        {
            // Create a collection of Link objects

            List<Link> links = new List<Link>();
            links.Add(new Link() { Rel = "collection", Href = "/api/albums" });
            links.Add(new Link() { Rel = "collection", Href = "/api/foo" });
            links.Add(new Link() { Rel = "collection", Href = "/api/bar" });
            links.Add(new Link() { Rel = "collection", Href = "/api/baz" });

            // Create and configure a dictionary to hold the collection

            Dictionary<string, List<Link>> linkList = new Dictionary<string, List<Link>>();
            linkList.Add("Links", links);

            return linkList;
        }

    }
}
