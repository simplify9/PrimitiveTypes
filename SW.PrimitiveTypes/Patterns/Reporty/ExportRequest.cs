using SW.PrimitiveTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SW.PrimitiveTypes
{
    public class ExportRequest
    {
        public CloudFilesOptions CloudFilesOptions { get; set; }
        public string ReportLocation { get; set; }
        public ReportDataSource DataSource { get; set; }
        public ExportFormat ExportFormat { get; set; }
        public IDictionary<string, string> Parameters { get; set; }
    }
}
