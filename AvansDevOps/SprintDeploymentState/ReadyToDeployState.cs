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
        private IDeploymentStateHolder _sprintStateHolder;
        public ReadyToDeployState(IDeploymentStateHolder sprintStateHolder)
        {
            _sprintStateHolder = sprintStateHolder;
        }

        public void CancelDeployment()
        {
            // TODO: Send notifications
            _sprintStateHolder.UpdateDeploymentState(new DeploymentCancelledState(_sprintStateHolder));
        }

        public void DeploymentFinished(bool success)
        {
            throw new NotImplementedException();
        }

        public void StartDeployment()
        {
            // Start pipeline
            _sprintStateHolder.UpdateDeploymentState(new InDeploymentState(_sprintStateHolder));
        }
    }
}
