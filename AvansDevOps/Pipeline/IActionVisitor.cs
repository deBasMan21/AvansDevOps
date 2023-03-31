using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Pipeline
{
    public interface IActionVisitor
    {
        public bool VisitPipeline(DeploymentPipeline pipeline);
        public bool VisitSources(SourcesAction sourcesAction);
        public bool VisitPackage(PackageAction packageAction);
        public bool VisitBuild(BuildAction buildAction);
        public bool VisitTest(TestAction testAction);
        public bool VisitDeploy(DeployAction deployAction);
        public bool VisitAnalyse(AnalyseAction analyseAction);
        public bool VisitUtility(UtilityAction utilityAction);
    }
}
