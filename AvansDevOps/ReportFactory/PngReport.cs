using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.ReportFactory
{
    public class PngReport : IReport
    {
        private string _content;
        private string? _footer;
        private string? _header;

        public PngReport(string content)
        {
            _content = content;
        }
        public void AddFooter(string content)
        {
            _footer = content;
        }

        public void AddHeader(string content)
        {
            _header = content;
        }

        public void CreateReport()
        {
            Console.WriteLine($"{_header}\n\n{_content}\n\n{_footer}");
        }
    }
}
