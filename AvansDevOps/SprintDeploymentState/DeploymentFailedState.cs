using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansDevOps.Pipeline;
using AvansDevOps.SprintAbstraction;

namespace AvansDevOps.SprintDeploymentState
{
    public class DeploymentFailedState : IDeploymentState
    {
        private readonly ReleaseSprint _sprint;

        public DeploymentFailedState(ReleaseSprint _sprint) => this._sprint = _sprint;

        public void ApproveDeployment() => Console.WriteLine("Deployment needs to be restarted or cancelled..");

        public int CancelDeployment()
        {
            _sprint.UpdateDeploymentState(new DeploymentCancelledState(_sprint));
            return _sprint.SendCancelDeploymentNotifications();
        }

        public void RestartDeployment() => _sprint.UpdateDeploymentState(new ReadyToDeployState(_sprint));


        public bool StartDeployment(DeploymentPipeline pipeline) => false;


        public int FinishDeployment(bool succeeded) => 0;
    }
}
