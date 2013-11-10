using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExceptionFilter.ViewModels
{
    // This source code file has classes for link relations

    // There is a 'Link' class that models a hypermedia link 

    // There are two abstract classes 
    // One is for a single linked item 
    // The other is for a linked collection

    // A view model class can inherit from one of these classes
    // The biggest benefit is the reduction in code-writing
    // For example, the LinkedItem<T> abstract class can be used as the 
    // base class for a 'Product' linked item, or for a 'Supplier' linked item
    // Study the source code for a view model class cluster to see how it's used

    /// <summary>
    /// A hypermedia link
    /// </summary>
    public class Link
    {
        /// <summary>
        /// Rel - relation
        /// </summary>
        public string Rel { get; set; }
        /// <summary>
        /// Href - hypermedia reference
        /// </summary>
        public string Href { get; set; }
    }

    /// <summary>
    /// Encloses an 'item' in a media type that has a 'Links' collection
    /// </summary>
    /// <typeparam name="T">View model object</typeparam>
    public abstract class LinkedItem<T>
    {
        public LinkedItem()
        {
            this.Links = new List<Link>();
        }

        public List<Link> Links { get; set; }
        public T Item { get; set; }
    }

    /// <summary>
    /// Encloses a 'collection' in a media type that has a 'Links' collection
    /// </summary>
    /// <typeparam name="T">View model collection</typeparam>
    public abstract class LinkedCollection<T>
    {
        public LinkedCollection()
        {
            this.Links = new List<Link>();
        }

        public List<Link> Links { get; set; }
        public IEnumerable<T> Collection { get; set; }
    }

}
