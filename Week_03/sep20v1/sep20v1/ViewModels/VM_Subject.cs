﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// more...
using System.ComponentModel.DataAnnotations;

namespace sep20v1.ViewModels
{
    // Choose unique names for the view model classes
    // Do not re-use the original class name (in the app domain data model)

    // Just the fields that are useful for a lookup list
    public class SubjectList
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        // Or, as an alternative to the above two fields...
        public string CodeAndName { get { return Code + " - " + Name; } }
    }

    // A template for displaying public properties
    // We need the data annotations here, because the inherited SubjectFull class
    // is used for update (PUT) operations
    public class SubjectPublic
    {
        // Reminder - when writing your own property, 
        // create a private field as a backing store
        private string _code = "";

        [Required]
        [RegularExpression(@"[a-zA-Z]{3}\d{3}")]
        public string Code
        {
            get { return _code; }
            set
            {
                // Make sure the incoming data gets set to upper case
                _code = value.ToUpper();
            }
        }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(5000)]
        public string Description { get; set; }
    }

    // A template for adding a 'new' Subject object
    // Notice that there's no 'Id' field, because that's auto-generated by the data store
    // We MUST provide a Program identifier
    public class SubjectAdd
    {
        // Reminder - when writing your own property, 
        // create a private field as a backing store
        private string _code = "";

        public SubjectAdd()
        {
            this.ProgramId = 0;
        }

        [Required]
        [RegularExpression(@"[a-zA-Z]{3}\d{3}")]
        public string Code
        {
            get { return _code; }
            set
            {
                // Make sure the incoming data gets set to upper case
                _code = value.ToUpper();
            }
        }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(5000)]
        public string Description { get; set; }

        public int ProgramId { get; set; }
    }

    // For get-some and get-one tasks
    // For this entity, can also be used for editing
    // (for this simple class, it includes all properties)
    public class SubjectFull : SubjectPublic
    {
        public int Id { get; set; }
    }

    // Subject with Program info
    public class SubjectWithProgram : SubjectFull
    {
        public int ProgramId { get; set; }
        public string ProgramCode { get; set; }
    }

}
