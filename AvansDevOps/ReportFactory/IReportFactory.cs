using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.ReportFactory
{
    public interface IReportFactory
    {
        public IReport CreateReport(string content);

        public void AddCustomHeader(string header);

        public void AddCustomFooter(string footer);
    }
}
