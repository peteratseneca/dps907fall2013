using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// more...
using Newtonsoft.Json;
// Before typing the next statement, go to Solution Explorer, 
// right-click References, and choose 'Add Reference...' 
// Then, from the Assemblies > Framework list, choose/check
// System.Runtime.Serialization, and click OK 
using System.Runtime.Serialization;

// The Newtonsoft.Json assembly does the JSON serialization
// Use the 'JsonIgnore' attribute on a property when appropriate

// The System.Runtime.Serialization assembly does the XML serialization
// Use the 'IgnoreDataMember' attribute on a property when appropriate

namespace oct01securitybasic.ViewModels
{
    public class VehiclePublic
    {
        public int Year { get; set; }
        public string Model { get; set; }
        public string Trim { get; set; }
        public int MSRP { get; set; }
    }

    public class VehicleBase : VehiclePublic
    {
        public int Id { get; set; }
    }

    public class VehicleFull : VehicleBase
    {
        // These are image-related properties
        // For this code example, we do NOT expose them
        // during a normal JSON or XML serialization
        [JsonIgnore, IgnoreDataMember]
        public byte[] Photo { get; set; }
        [JsonIgnore, IgnoreDataMember]
        public string ContentType { get; set; }
    }

}
