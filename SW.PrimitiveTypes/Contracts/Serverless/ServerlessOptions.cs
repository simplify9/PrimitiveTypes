using SW.PrimitiveTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SW.PrimitiveTypes
{
    public class ServerlessOptions
    {

        public CloudFilesOptions CloudFilesOptions { get; set; }
        public string AdapterLocalPath { get; set; } = "./adapters";
        public int AdapterMetadataCacheDuration { get; set; } = 5;
        public string AdapterRemotePath { get; set; } = "adapters";
        public int CommandTimeout { get; set; } = 30;
        public int IdleTimeout { get; set; } = 300;
    }
}
