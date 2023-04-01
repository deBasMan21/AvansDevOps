using AvansDevOps.Pipeline;
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

        public int CancelDeployment()
        {
            _sprint.UpdateDeploymentState(new DeploymentCancelledState(_sprint));
            return _sprint.SendCancelDeploymentNotifications();
        }

        public void RestartDeployment() => Console.WriteLine("Deployments needs to be approved or cancelled..");


        public bool StartDeployment(DeploymentPipeline pipeline) => false;

        public int FinishDeployment(bool succeeded) => 0;
    }
}
