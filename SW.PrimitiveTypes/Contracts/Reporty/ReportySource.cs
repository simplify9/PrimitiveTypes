using System;
using System.Collections.Generic;
using System.Text;

namespace SW.PrimitiveTypes
{
    public class ReportySource
    {
        public ReportySourceType Type { get; set; }
        public string ServerName { get; set; }
        public string DatabaseName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public IDictionary<string, string>  Headers { get; set; }
    }
}
