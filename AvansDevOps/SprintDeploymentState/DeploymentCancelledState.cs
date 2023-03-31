using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansDevOps.SprintAbstraction;

namespace AvansDevOps.SprintDeploymentState
{
    public class DeploymentCancelledState : IDeploymentState
    {
        private readonly ReleaseSprint _sprint;

        public DeploymentCancelledState(ReleaseSprint _sprint) => this._sprint = _sprint;

        public void ApproveDeployment() => Console.WriteLine("Is already closed");

        public void CancelDeployment() => Console.WriteLine("Is already closed");

        public void FinishDeployment(bool succeeded) => Console.WriteLine("Is already closed");

        public void RestartDeployment() => Console.WriteLine("Is already closed");

        public bool StartDeployment(string gitUrl, List<string> dependencies, string buildType, string testFramework, string analyseTool, string deploymentTarget, List<string> utilityActions) => false;
    }
}
