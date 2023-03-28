using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Pipeline
{
    public class ActionVisitor : IActionVisitor
    {
        public void VisitAnalyse(AnalyseAction analyseAction)
        {
            analyseAction.RunAnalysis();
        }

        public void VisitBuild(BuildAction buildAction)
        {
            buildAction.RunBuild();
        }

        public void VisitDeploy(DeployAction deployAction)
        {
            deployAction.RunDeployment();
        }

        public void VisitPackage(PackageAction packageAction)
        {
            packageAction.InstallDependencies();
        }

        public void VisitPipeline(PipeLine pipeline)
        {
            Console.WriteLine("Run pipeline");
        }

        public void VisitSources(SourcesAction sourcesAction)
        {
           sourcesAction.CloneRepo();
        }

        public void VisitTest(TestAction testAction)
        {
            testAction.RunTests();
            testAction.PublishResults();
        }

        public void VisitUtility(UtilityAction utilityAction)
        {
            utilityAction.RunUtilityActions();
        }
    }
}
