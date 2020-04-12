using System;
using System.Collections.Generic;
using System.Text;

namespace SW.PrimitiveTypes
{ 
    public class WriteFileSettings
    {
        public WriteFileSettings()
        {
            Metadata = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        }


        /// <summary>
        /// It consists of the path and filename
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Content type of the file
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// Flag to set the file to be public viewed
        /// </summary>
        public bool Public { get; set; }

        /// <summary>
        /// Flag to close the input stream, default: true
        /// </summary>
        public bool CloseInputStream { get; set; } = true;

        /// <summary>
        /// File metadata dictionary to be saved 
        /// </summary>
        public IDictionary<string, string> Metadata { get; set; }
    }
}
