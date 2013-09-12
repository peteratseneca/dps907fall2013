using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sep13v1.Models
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
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public int Semesters { get; set; }
        public string Credential { get; set; }

        public ICollection<Subject> Subjects { get; set; }
    }

    public class Subject
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Program Program { get; set; }
    }
}
