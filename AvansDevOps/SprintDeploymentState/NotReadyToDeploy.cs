using AvansDevOps.SprintAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.SprintDeploymentState
{
    public class NotReadyToDeploy : IDeploymentState
    {
        private readonly ReleaseSprint _sprint;

        public NotReadyToDeploy(ReleaseSprint _sprint) => this._sprint = _sprint;

        public void ApproveDeployment() => _sprint.UpdateDeploymentState(new ReadyToDeployState(_sprint));

        public void CancelDeployment()
        {
            // TODO: send notifications
            _sprint.UpdateDeploymentState(new DeploymentCancelledState(_sprint));
        }

        public void RestartDeployment() => Console.WriteLine("Deployments needs to be approved or cancelled..");


        public bool StartDeployment(string gitUrl, List<string> dependencies, string buildType, string testFramework, string analyseTool, string deploymentTarget, List<string> utilityActions) => false;

        public void FinishDeployment(bool succeeded) => Console.WriteLine("Deployments needs to be approved or cancelled..");
    }
}
