using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// more...
using System.ComponentModel.DataAnnotations;

namespace RelationOneToManySelf.ViewModels
{
    // Typical data annotations for add/update view models:
    // Required, StringLength, Range, RegularExpression

    // Typical view model class names:
    // List - for a lookup list 
    // Add - for add-new task
    // AddTemplate - string properties, getters only, with descriptive text...
    // (Info/description; data type; required; size/length/range/regex) 
    // Base - public, includes identifier property
    // Edit - for update-item task
    // Full - all properties, or the most-commonly-delivered representation
    // Link - above, with a 'Link' property

    /*
    public class AlbumAddTemplate
    {
        public string Name { get { return "Album name; string; required; 200 characters"; } }
        public string Artist { get { return "Artist name; string; required; 500 characters"; } }
        public string YearReleased { get { return "Year released; int; required; year 1880 or later"; } }
        public string Genre { get { return "Album genre; string; required; 200 characters"; } }
    }

    public class AlbumLinked : LinkedItem<AlbumLink> { }

    public class AlbumsLinked : LinkedCollection<AlbumLink>
    {
        public AlbumsLinked()
        {
            this.Template = new AlbumAddTemplate();
        }

        public AlbumAddTemplate Template { get; set; }
    }
    */

}
