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
        private ReleaseSprint _sprint;

        public NotReadyToDeploy(ReleaseSprint _sprint)
        {
            this._sprint = _sprint;
        }

        public void ApproveDeployment()
        {
            _sprint.UpdateDeploymentState(new ReadyToDeployState(_sprint));
        }

        public void CancelDeployment()
        {
            // TODO: send notifications
            _sprint.UpdateDeploymentState(new DeploymentCancelledState(_sprint));
        }

        public void FailDeployment()
        {
            return;
        }

        public void RestartDeployment()
        {
            return;
        }

        public void StartDeployment()
        {
            return;
        }

        public void SucceedDeployment()
        {
            return;
        }
    }
}
