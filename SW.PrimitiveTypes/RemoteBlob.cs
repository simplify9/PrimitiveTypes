using System;
using System.Collections.Generic;
using System.Text;

namespace SW.PrimitiveTypes
{
    public class RemoteBlob
    {
        public Uri Uri { get; set; }
        public int Size { get; set; }
        public string MimeType { get; set; }
        public string Name { get; set; }

    }
}
