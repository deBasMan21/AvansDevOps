using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.SprintDeploymentState
{
    public interface IDeploymentState
    {
        void ApproveDeployment();
        void StartDeployment();
        void CancelDeployment();
        void FailDeployment();
        void SucceedDeployment();
        void RestartDeployment();
    }
}
