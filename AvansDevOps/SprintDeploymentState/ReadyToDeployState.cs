using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansDevOps.Pipeline;
using AvansDevOps.SprintAbstraction;

namespace AvansDevOps.SprintDeploymentState
{
    public class ReadyToDeployState : IDeploymentState
    {
        private readonly ReleaseSprint _sprint;

        public ReadyToDeployState(ReleaseSprint _sprint) => this._sprint = _sprint;

        public void ApproveDeployment() => Console.WriteLine("Deployments needs to be started..");

        public int CancelDeployment() => 0;

        public void RestartDeployment() => Console.WriteLine("Deployments needs to be started..");

        public bool StartDeployment(DeploymentPipeline pipeline) {
            ActionVisitor visitor = new ();

            _sprint.UpdateDeploymentState(new InDeploymentState(_sprint));

            return pipeline.AcceptVisitor(visitor); // Run all actions

        }

        public int FinishDeployment(bool succeeded) => 0;
    }
}
