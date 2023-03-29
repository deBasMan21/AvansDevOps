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
        private ReleaseSprint _sprint;

        public InDeploymentState(ReleaseSprint _sprint)
        {
            this._sprint = _sprint;
        }

        public void ApproveDeployment()
        {
            return;

        }

        public void CancelDeployment()
        {
            return;
        }

        public void FailDeployment()
        {
            _sprint.UpdateDeploymentState(new DeploymentFailedState(_sprint));
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
            _sprint.UpdateDeploymentState(new ReleasedDeploymentState(_sprint));

        }
    }
}
