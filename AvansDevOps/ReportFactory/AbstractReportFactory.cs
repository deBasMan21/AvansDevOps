using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.ReportFactory
{
    public class AbstractReportFactory
    {
        public AbstractReportFactory() { }

        public IReportFactory CreatePngReportFactory()
        {
            return new ReportFactory(ReportType.PNG);
        }

        public IReportFactory CreatePdfReportFactory()
        {
            return new ReportFactory(ReportType.PDF);
        }
    }
}
