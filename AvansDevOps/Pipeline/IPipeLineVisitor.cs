using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Pipeline
{
    public interface IPipeLineVisitor
    {
        public void VisitPipeline(PipeLine pipeline);
        public void VisitSources(SourcesAction sourcesAction);
        public void VisitPackage(PackageAction packageAction);
        public void VisitBuild(BuildAction buildAction);
        public void VisitTest(TestAction testAction);
        public void VisitDeploy(DeployAction utilityAction);
        public void VisitAnalyse(AnalyseAction analyseAction);
        public void VisitUtility(UtilityAction utilityAction);
    }
}
