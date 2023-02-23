using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.ReportFactory
{
    public class ReportFactory: IReportFactory
    {
        private ReportType _reportType;
        public ReportFactory(ReportType type) 
        {
            _reportType = type;
        }

        public IReport CreateReport(string content)
        {
            switch (_reportType)
            {
                case ReportType.PDF: return new PdfReport(content);
                case ReportType.PNG: return new PngReport(content);
                default: return null;
            }
        }
    }

    public enum ReportType
    {
        PDF,
        PNG
    }

    public interface IReportFactory
    {
        IReport CreateReport(string content);
    }
}
