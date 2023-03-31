using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.ReportFactory
{
    public class ReportFactory
    {
        public ReportFactory() { }

        public IReportFactory CreatePDFReportFactory() => new PdfReportFactory();

        public IReportFactory CreatePNGReportFactory() => new PngReportFactory();
    }
}
