using AvansDevOps.Pipeline;
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
        bool StartDeployment(DeploymentPipeline pipeline);
        void CancelDeployment();
        void FinishDeployment(bool succeeded);
        void RestartDeployment();
    }
}
