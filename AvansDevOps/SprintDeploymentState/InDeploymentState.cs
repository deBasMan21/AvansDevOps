using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansDevOps.SprintAbstraction;

namespace AvansDevOps.SprintDeploymentState
{
    public class InDeploymentState : IDeploymentState
    {
        private readonly ReleaseSprint _sprint;

        public InDeploymentState(ReleaseSprint _sprint) => this._sprint = _sprint;

        public void ApproveDeployment() { }

        public void CancelDeployment() { }

        public void FailDeployment() => _sprint.UpdateDeploymentState(new DeploymentFailedState(_sprint));

        public void RestartDeployment() { }

        public bool StartDeployment(string gitUrl, List<string> dependencies, string buildType, string testFramework, string analyseTool, string deploymentTarget, List<string> utilityActions) => false;

        public void FinishDeployment(bool succeeded)
        {
            if (succeeded)
            {
                Console.WriteLine("pipeline succeeded");
                _sprint.UpdateDeploymentState(new ReleasedDeploymentState(_sprint));
            }
            else {
                // TODO: Send notification
                Console.WriteLine("pipeline failed");
                _sprint.UpdateDeploymentState(new DeploymentFailedState(_sprint));
            }
        }

    }
}
