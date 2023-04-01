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

        public void ApproveDeployment() => Console.WriteLine("Is already closed");

        public int CancelDeployment() => 0;

        public int FinishDeployment(bool succeeded) => 0;

        public void RestartDeployment() => Console.WriteLine("Is already closed");

        public bool StartDeployment(DeploymentPipeline pipeline) => false;
    }
}
