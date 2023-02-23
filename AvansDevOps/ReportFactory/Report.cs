using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.ReportFactory
{
    public interface IReport
    {
        public void CreateReport();
        public void AddHeader(string content);
        public void AddFooter(string content);
    }
}
