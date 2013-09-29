using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// more
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using sep24images.ViewModels;
using System.IO;

namespace sep24images.Formatters
{
    public class ImageFormatter : BufferedMediaTypeFormatter
    {
        // Need five methods:
        // 1. Constructor
        // 2. Can read?
        // 3. Reader
        // 4. Can write?
        // 5. Writer

        public ImageFormatter()
        {
            // Add the supported media types - jpeg and png only for this code example
            this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("image/jpeg"));
            this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("image/png"));
            this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("image/gif"));
        }

        // Can this formatter read?
        // Enables a client/user to "upload" an image
        // Example usage - PUT a new/updated image
        public override bool CanReadType(Type type)
        {
            return (type == typeof(byte[]));
        }

        // This method reads bytes from an input stream (i.e. an "upload")
        public override object ReadFromStream(Type type, System.IO.Stream readStream, System.Net.Http.HttpContent content, IFormatterLogger formatterLogger)
        {
            // Create an in-memory buffer
            var ms = new MemoryStream();
            // Copy the request message body content to the in-memory buffer
            readStream.CopyTo(ms);
            // Deliver a byte array to the controller
            return ms.ToArray();
        }

        // Can this formatter write?
        // Delivers an image to a client/user
        // Example usage - GET an image
        public override bool CanWriteType(Type type)
        {
            return (type == typeof(VehicleFull));
        }

        // This method writes bytes to the output stream
        public override void WriteToStream(Type type, object value, System.IO.Stream writeStream, System.Net.Http.HttpContent content)
        {
            // Cast the value parameter
            VehicleFull v = (VehicleFull)value;

            // Extract the image bytes to an in-memory buffer
            var ms = new MemoryStream(v.Photo);
            // Deliver the bytes
            ms.CopyTo(writeStream);
        }

    }

}
