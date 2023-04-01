using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.ReportFactory
{
    public class ReportFactory
    {
        protected ReportFactory() { }

        public static IReportFactory CreatePDFReportFactory() => new PdfReportFactory();

        public static IReportFactory CreatePNGReportFactory() => new PngReportFactory();
    }
}
