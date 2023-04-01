using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansDevOps.Pipeline;
using AvansDevOps.SprintAbstraction;
using AvansDevOps.UserAbstraction;

namespace AvansDevOps.SprintDeploymentState
{
    public class InDeploymentState : IDeploymentState
    {
        private readonly ReleaseSprint _sprint;

        public InDeploymentState(ReleaseSprint _sprint) => this._sprint = _sprint;

        public void ApproveDeployment() => Console.WriteLine("Deployment needs to be finished..");

        public int CancelDeployment() => 0;

        public void RestartDeployment() => Console.WriteLine("Deployment needs to be finished..");

        public bool StartDeployment(DeploymentPipeline pipeline) => false;

        public int FinishDeployment(bool succeeded)
        {
            if (succeeded)
            {
                Console.WriteLine("pipeline succeeded");
                _sprint.UpdateDeploymentState(new ReleasedDeploymentState(_sprint));
            }
            else {
                Console.WriteLine("pipeline failed");
                _sprint.UpdateDeploymentState(new DeploymentFailedState(_sprint));
            }

            string notificationString = succeeded ? "Deployment for release succeeded" : "Deployment for release failed";
            int notificationCount = _sprint.Notify(notificationString, typeof(ScrumMaster));
            if (succeeded) { notificationCount += _sprint.Notify(notificationString, typeof(ScrumMaster)); }
            return notificationCount;
        }

    }
}
