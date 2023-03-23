using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansDevOps.SprintAbstraction;

namespace AvansDevOps.SprintDeploymentState
{
    class InDeploymentState : IDeploymentState
    {
        private IDeploymentStateHolder _sprintStateHolder;
        public InDeploymentState(IDeploymentStateHolder sprintStateHolder)
        {
            _sprintStateHolder = sprintStateHolder;
        }

        public void CancelDeployment()
        {
            throw new NotImplementedException();
        }

        public void DeploymentFinished(bool success)
        {
            // TODO: Send notifications
            if (success)
            {
                _sprintStateHolder.UpdateDeploymentState(new ReleasedDeploymentState(_sprintStateHolder));
            } else
            {
                _sprintStateHolder.UpdateDeploymentState(new DeploymentFailedState(_sprintStateHolder));
            }
        }

        public void StartDeployment()
        {
            throw new NotImplementedException();
        }
    }
}
