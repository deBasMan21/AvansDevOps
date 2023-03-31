using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansDevOps.SprintAbstraction;

namespace AvansDevOps.SprintDeploymentState
{
    public class ReadyToDeployState : IDeploymentState
    {
        private readonly ReleaseSprint _sprint;

        public ReadyToDeployState(ReleaseSprint _sprint) => this._sprint = _sprint;

        public void ApproveDeployment() { }

        public void CancelDeployment() { }

        public void FailDeployment() { }

        public void RestartDeployment() { }

        public void StartDeployment() => _sprint.UpdateDeploymentState(new InDeploymentState(_sprint));

        public void SucceedDeployment() { }
    }
}
