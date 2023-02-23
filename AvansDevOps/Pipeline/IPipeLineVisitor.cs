using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Pipeline
{
    public interface IPipeLineVisitor
    {
        public void VisitSources();
        public void VisitPackage();
        public void VisitBuild();
        public void VisitTest();
        public void VisitAnalyse();
        public void VisitUtility();
    }
}
