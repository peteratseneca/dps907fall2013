using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sep02v3.Models
{
    public class StoreInitializer
    {
        /// <summary>
        /// Collection of Colour objects
        /// </summary>
        public List<Colour> Colours { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public StoreInitializer()
        {
            // Initialize
            this.Colours = new List<Colour>();

            // Create some Colour objects
            this.Colours.Add(new Colour() { Id = this.Colours.Count + 1, ColourName = "Red" });
            this.Colours.Add(new Colour() { Id = this.Colours.Count + 1, ColourName = "Green" });
            this.Colours.Add(new Colour() { Id = this.Colours.Count + 1, ColourName = "Blue" });
            this.Colours.Add(new Colour() { Id = this.Colours.Count + 1, ColourName = "Yellow" });
            this.Colours.Add(new Colour() { Id = this.Colours.Count + 1, ColourName = "Orange" });
            this.Colours.Add(new Colour() { Id = this.Colours.Count + 1, ColourName = "Brown" });
        }

    }
}
