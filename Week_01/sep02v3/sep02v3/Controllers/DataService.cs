using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// more...
using sep02v3.Models;

namespace sep02v3.Controllers
{
    public class DataService
    {
        // Private, so it's not visible outside the class
        private List<Colour> Colours { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public DataService()
        {
            // Fetch the data from the application state
            this.Colours = (List<Colour>)HttpContext.Current.Application["Colours"];
        }

        // All colour names
        public List<string> GetColourNames()
        {
            // Transform the Colours collection to a simple string collection
            List<string> colourNames = new List<string>();
            foreach (var colour in this.Colours)
            {
                colourNames.Add(colour.ColourName);
            }
            return colourNames;
        }

        // One colour by its id
        public string GetColourById(int id)
        {
            var colour = this.Colours.SingleOrDefault(i => i.Id == id);
            return (colour == null) ? null : colour.ColourName;
        }

        // Add a new colour
        public string AddColour(string colourName)
        {
            if (string.IsNullOrEmpty(colourName))
            {
                return null;
            }
            else
            {
                // Optional, for your learning enjoyment 
                var fixer = new System.Globalization.CultureInfo("en-ca").TextInfo;
                colourName = fixer.ToTitleCase(colourName);
                
                // Add a new Colour object
                this.Colours.Add(new Colour() { Id = this.Colours.Count + 1, ColourName = colourName });
                // Save to application state
                HttpContext.Current.Application["Colours"] = this.Colours;

                return colourName;
            }
        }

        // Other methods would 'edit/modify' or 'delete' a colour

    }
}
