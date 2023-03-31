using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansDevOps.SprintAbstraction;

namespace AvansDevOps.SprintDeploymentState
{
    public class ReleasedDeploymentState : IDeploymentState
    {
        private readonly ReleaseSprint _sprint;

        public ReleasedDeploymentState(ReleaseSprint _sprint) => this._sprint = _sprint;

        public void ApproveDeployment() => Console.WriteLine("Deployments has already been released");

        public void CancelDeployment() => Console.WriteLine("Deployments has already been released");

        public void RestartDeployment() => Console.WriteLine("Deployments has already been released");

        public bool StartDeployment(string gitUrl, List<string> dependencies, string buildType, string testFramework, string analyseTool, string deploymentTarget, List<string> utilityActions) => false;

        public void FinishDeployment(bool succeeded) => Console.WriteLine("Deployments has already been released");
    }
}
