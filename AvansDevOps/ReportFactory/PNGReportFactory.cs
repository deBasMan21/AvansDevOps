using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.ReportFactory
{
    public class PNGReportFactory: IReportFactory
    {
        private string? customHeader = null;
        private string? customFooter = null;
        public PNGReportFactory() { }

        public void AddCustomFooter(string footer) => customFooter = footer;

        public void AddCustomHeader(string header) => customHeader = header;

        public IReport CreateReport(string content)
        {
            IReport report = new PngReport(content);

            if (customFooter != null)
            {
                report.AddFooter(customFooter);
            }

            if (customHeader != null)
            {
                report.AddHeader(customHeader);
            }

            return report;
        }
    }
}
