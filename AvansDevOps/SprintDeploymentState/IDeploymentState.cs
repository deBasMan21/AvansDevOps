using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.SprintDeploymentState
{
    public interface IDeploymentState
    {
        void StartDeployment();
        void DeploymentFinished(bool success);
        void CancelDeployment();
    }
}
