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

        public void ApproveDeployment() { }

        public void CancelDeployment() { }

        public void RestartDeployment() { }

        public bool StartDeployment(DeploymentPipeline pipeline) {
            ActionVisitor visitor = new ();

            _sprint.UpdateDeploymentState(new InDeploymentState(_sprint));

            return pipeline.AcceptVisitor(visitor); // Run all actions

        }

        public void FinishDeployment(bool succeeded)
        {
            return;
        }
    }
}
