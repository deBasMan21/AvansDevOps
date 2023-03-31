using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansDevOps.Pipeline;
using AvansDevOps.SprintAbstraction;

namespace AvansDevOps.SprintDeploymentState
{
    public class ReadyToDeployState : IDeploymentState
    {
        private readonly ReleaseSprint _sprint;

        public ReadyToDeployState(ReleaseSprint _sprint) => this._sprint = _sprint;

        public void ApproveDeployment() => Console.WriteLine("Deployments needs to be started..");

        public void CancelDeployment() => Console.WriteLine("Deployments needs to be started..");

        public void RestartDeployment() => Console.WriteLine("Deployments needs to be started..");

        public bool StartDeployment(string gitUrl, List<string> dependencies, string buildType, string testFramework, string analyseTool, string deploymentTarget, List<string> utilityActions) {
            DeploymentPipeline pipeline = new();
            ActionVisitor visitor = new ();

            pipeline.AddComponent(new SourcesAction(gitUrl));
            pipeline.AddComponent(new PackageAction(dependencies));
            pipeline.AddComponent(new BuildAction(buildType));
            pipeline.AddComponent(new TestAction(testFramework));
            pipeline.AddComponent(new AnalyseAction(analyseTool));
            pipeline.AddComponent(new DeployAction(deploymentTarget));
            pipeline.AddComponent(new UtilityAction(utilityActions));

            _sprint.UpdateDeploymentState(new InDeploymentState(_sprint));

            return pipeline.AcceptVisitor(visitor); // Run all actions

        }

        public void FinishDeployment(bool succeeded) => Console.WriteLine("Deployments needs to be started..");
    }
}
