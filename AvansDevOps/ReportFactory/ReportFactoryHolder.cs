using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.ReportFactory
{
    public class ReportFactoryHolder
    {
        public ReportFactoryHolder() { }

        public IReportFactory CreateReportFactory(ReportType type)
        {
            return type switch
            {
                ReportType.PNG => CreatePNGReportFactory(),
                ReportType.PDF => CreatePDFReportFactory(),
                _ => throw new NotImplementedException(),
            };
        }

        private IReportFactory CreatePDFReportFactory() => new PdfReportFactory();

        private IReportFactory CreatePNGReportFactory() => new PngReportFactory();
    }
}
