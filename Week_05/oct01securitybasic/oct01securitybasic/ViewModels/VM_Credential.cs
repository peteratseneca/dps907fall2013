using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using System.ComponentModel.DataAnnotations;

namespace oct01securitybasic.ViewModels
{
    // Simple credential class design
    // It includes only one "Role"
    // A more complete credential store design would include a Role class
    // Then, a "User" could have a collection of zero or more "Roles" 

    public class CredentialFull
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Scheme { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }

    public class CredentialAdd
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public string Scheme { get; set; }
        public string Role { get; set; }
    }

}
