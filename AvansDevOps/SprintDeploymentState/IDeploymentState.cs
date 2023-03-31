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
        bool StartDeployment(string gitUrl, List<string> dependencies, string buildType, string testFramework, string analyseTool, string deploymentTarget, List<string> utilityActions);
        void CancelDeployment();
        void FinishDeployment(bool succeeded);
        void RestartDeployment();
    }
}
