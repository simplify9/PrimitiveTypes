using SW.PrimitiveTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SW.PrimitiveTypes
{
    public class ReportyRequest
    {
        public ReportyRequest()
        {
            ExportFormat = ReportyFormat.Pdf;
        }

        public CloudFilesOptions CloudFilesOptions { get; set; }
        public string ReportLocation { get; set; }
        public ReportySource DataSource { get; set; }
        public ReportyFormat ExportFormat { get; set; }
        public IDictionary<string, string> Parameters { get; set; }
    }
}
