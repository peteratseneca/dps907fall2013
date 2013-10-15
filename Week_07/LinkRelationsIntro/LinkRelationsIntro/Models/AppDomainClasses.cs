using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinkRelationsIntro.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
        // Needs a range in the view model
        public int YearReleased { get; set; }
        public string Genre { get; set; }
        public string MediaType { get; set; }
        public byte[] AlbumCover { get; set; }
        // Needs a range in the view model
        public int Rating { get; set; }
        public bool IsInfoShared { get; set; }
    }
}
