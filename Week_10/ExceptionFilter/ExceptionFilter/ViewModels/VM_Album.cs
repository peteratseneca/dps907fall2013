using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// more...
using System.ComponentModel.DataAnnotations;

namespace ExceptionFilter.ViewModels
{
    public class AlbumList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
    }

    public class AlbumAdd
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Artist { get; set; }
        [Range(1880, 9000)]
        public int YearReleased { get; set; }
        [Required]
        public string Genre { get; set; }
    }

    /// <summary>
    /// An 'add new album' template 
    /// </summary>
    public class AlbumAddTemplate
    {
        public string Name { get { return "Album name; string; required; 200 characters"; } }
        public string Artist { get { return "Artist name; string; required; 500 characters"; } }
        public string YearReleased { get { return "Year released; int; required; year 1880 or later"; } }
        public string Genre { get { return "Album genre; string; required; 200 characters"; } }
    }

    public class AlbumFull : AlbumAdd
    {
        public int Id { get; set; }
    }

    /// <summary>
    /// AlbumLink extends AlbumFull by adding a 'Link' property
    /// </summary>
    public class AlbumLink : AlbumFull
    {
        /// <summary>
        /// A Link includes an href and a rel
        /// </summary>
        public Link Link { get; set; }
    }

    /// <summary>
    /// Custom media type with link relations, for an 'item'
    /// </summary>
    public class AlbumLinked : LinkedItem<AlbumLink> { }

    /// <summary>
    /// Custom media type with link relations, for a 'collection'
    /// </summary>
    public class AlbumsLinked : LinkedCollection<AlbumLink>
    {
        public AlbumsLinked()
        {
            this.Template = new AlbumAddTemplate();
        }

        public AlbumAddTemplate Template { get; set; }
    }

}
