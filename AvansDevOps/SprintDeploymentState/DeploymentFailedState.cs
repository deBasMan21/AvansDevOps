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

        public void ApproveDeployment() { }

        public void CancelDeployment()
        {
            // TODO: send notification
            _sprint.UpdateDeploymentState(new DeploymentCancelledState(_sprint));
        }


        public void RestartDeployment() => _sprint.UpdateDeploymentState(new ReadyToDeployState(_sprint));


        public bool StartDeployment(DeploymentPipeline pipeline) => false;


        public void FinishDeployment(bool succeeded)
        {
            return;
        }
    }
}
