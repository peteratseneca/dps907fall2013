using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using System.ComponentModel.DataAnnotations;

namespace SecurityUsingOAuth.Models
{
    public class Credential
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public string Scheme { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }

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

        public string ContentType { get; set; }
        // Internet media types are stored as byte arrays
        public byte[] Photo { get; set; }
    }

}
