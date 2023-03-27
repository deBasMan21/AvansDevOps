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
        private ReleaseSprint _sprint;

        public DeploymentCancelledState(ReleaseSprint _sprint)
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
