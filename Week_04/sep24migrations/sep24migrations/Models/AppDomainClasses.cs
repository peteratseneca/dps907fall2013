using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace sep24migrations.Models
{
    // This app domain data model has two entities:
    // Program - an academic program in the School of ICT 
    // Subject - a subject in the program's curriculum
    // Entity associations are coded as simple properties...
    // To-one (reference to another class)
    // To-many (reference to a collection of another class)

    public class Program
    {
        // Required - default constructor if you have a collection property
        // You can also add code to set defaults for other properties, if you wish
        public Program()
        {
            this.Subjects = new List<Subject>();
            this.DateCreated = DateTime.Now;
        }

        public int Id { get; set; }

        public string Code { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(5000)]
        public string Description { get; set; }

        public DateTime DateCreated { get; set; }
        public int Semesters { get; set; }

        [Required]
        [StringLength(50)]
        public string Credential { get; set; }

        public ICollection<Subject> Subjects { get; set; }
    }

    public class Subject
    {
        public Subject()
        {
            this.Status = "Current"; // Retired, Future
            this.DateCreated = DateTime.Now;
        }

        public int Id { get; set; }
        public string Code { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(5000)]
        public string Description { get; set; }

        public string Status { get; set; }
        public DateTime DateCreated { get; set; }

        public Program Program { get; set; }
    }
}
