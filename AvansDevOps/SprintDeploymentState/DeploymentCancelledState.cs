using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansDevOps.Pipeline;
using AvansDevOps.SprintAbstraction;

namespace AvansDevOps.SprintDeploymentState
{
    public class DeploymentCancelledState : IDeploymentState
    {
        private readonly ReleaseSprint _sprint;

        public DeploymentCancelledState(ReleaseSprint _sprint) => this._sprint = _sprint;

        public void ApproveDeployment() { }

        public void CancelDeployment() { }

        public void FinishDeployment(bool succeeded)
        {
            return;
        }

        public void RestartDeployment() { }

        public bool StartDeployment(DeploymentPipeline pipeline) => false;
    }
}
