using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.ReportFactory
{
    public class ReportFactoryHolder
    {
        public static IReportFactory CreateReportFactory(ReportType type)
        {
            return type switch
            {
                ReportType.PNG => CreatePNGReportFactory(),
                ReportType.PDF => CreatePDFReportFactory(),
                _ => throw new NotImplementedException(),
            };
        }

        private static IReportFactory CreatePDFReportFactory() => new PdfReportFactory();

        private static IReportFactory CreatePNGReportFactory() => new PngReportFactory();
    }
}
