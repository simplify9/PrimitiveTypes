using System;
using System.Collections.Generic;
using System.Text;

namespace SW.PrimitiveTypes
{ 
    public class WriteFileSettings
    {
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
    }
}
