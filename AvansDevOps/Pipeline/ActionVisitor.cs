using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Pipeline
{
    public class ActionVisitor : IActionVisitor
    {
        public bool VisitAnalyse(AnalyseAction analyseAction) => analyseAction.RunAnalysis();
        public bool VisitBuild(BuildAction buildAction) => buildAction.RunBuild();
        public bool VisitDeploy(DeployAction deployAction) => deployAction.RunDeployment();
        public bool VisitPackage(PackageAction packageAction) => packageAction.InstallDependencies();
        public bool VisitPipeline(DeploymentPipeline pipeline) => pipeline.StartPipeline();
        public bool VisitSources(SourcesAction sourcesAction) => sourcesAction.CloneRepo();
        public bool VisitTest(TestAction testAction) => testAction.RunTests() && testAction.PublishResults();
        public bool VisitUtility(UtilityAction utilityAction) => utilityAction.RunUtilityActions();
    }
}
