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

        public void StartDeployment() { }

        public void SucceedDeployment() => _sprint.UpdateDeploymentState(new ReleasedDeploymentState(_sprint));
    }
}
