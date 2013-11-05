using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// more...
using EnumTypes.OtherClassesAndEnums;

namespace EnumTypes.Models
{
    public class Vehicle
    {
        public Vehicle()
        {
            this.Year = DateTime.Now.Year;
        }

        public int Id { get; set; }
        public int Year { get; set; }
        public string Model { get; set; }
        public string Trim { get; set; }
        public int MSRP { get; set; }

        public BodyStyle BodyStyle { get; set; }

        public string ContentType { get; set; }
        // Internet media types are stored as byte arrays
        public byte[] Photo { get; set; }
    }

}
