using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansDevOps.Pipeline;
using AvansDevOps.SprintAbstraction;

namespace AvansDevOps.SprintDeploymentState
{
    public class ReleasedDeploymentState : IDeploymentState
    {
        private readonly ReleaseSprint _sprint;

        public ReleasedDeploymentState(ReleaseSprint _sprint) => this._sprint = _sprint;

        public void ApproveDeployment() => Console.WriteLine("Deployments has already been released");

        public int CancelDeployment() => 0;

        public void RestartDeployment() => Console.WriteLine("Deployments has already been released");

        public bool StartDeployment(DeploymentPipeline pipeline) => false;

        public int FinishDeployment(bool succeeded) => 0;
    }
}
