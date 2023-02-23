using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Pipeline
{
    public class RunPipelineVisitor : IPipeLineVisitor
    {
        public void VisitAnalyse(AnalyseAction analyseAction)
        {
            Console.WriteLine("Run analyse action");
        }

        public void VisitBuild(BuildAction buildAction)
        {
            Console.WriteLine("Run build action");
        }

        public void VisitDeploy(DeployAction utilityAction)
        {
            Console.WriteLine("Run utility action");
        }

        public void VisitPackage(PackageAction packageAction)
        {
            Console.WriteLine("Run package action");
        }

        public void VisitPipeline(PipeLine pipeline)
        {
            Console.WriteLine("Run pipeline");
        }

        public void VisitSources(SourcesAction sourcesAction)
        {
            Console.WriteLine("Run sources action");
        }

        public void VisitTest(TestAction testAction)
        {
            Console.WriteLine("Run test action");
        }

        public void VisitUtility(UtilityAction utilityAction)
        {
            Console.WriteLine("Run utility action");
        }
    }
}
