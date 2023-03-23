using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansDevOps.SprintAbstraction;

namespace AvansDevOps.SprintDeploymentState
{
    public class ReleasedDeploymentState : IDeploymentState
    {
        private IDeploymentStateHolder _sprintStateHolder;
        public ReleasedDeploymentState(IDeploymentStateHolder sprintStateHolder) 
        {
            _sprintStateHolder = sprintStateHolder;
        }

        public void CancelDeployment()
        {
            throw new NotImplementedException();
        }

        public void DeploymentFinished(bool success)
        {
            throw new NotImplementedException();
        }

        public void StartDeployment()
        {
            throw new NotImplementedException();
        }
    }
}
