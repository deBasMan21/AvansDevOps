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
        private readonly ReleaseSprint _sprint;

        public ReleasedDeploymentState(ReleaseSprint _sprint) => this._sprint = _sprint;

        public void ApproveDeployment() { }

        public void CancelDeployment() { }

        public void RestartDeployment() { }

        public bool StartDeployment(string gitUrl, List<string> dependencies, string buildType, string testFramework, string analyseTool, string deploymentTarget, List<string> utilityActions) => false;

        public void FinishDeployment(bool succeeded)
        {
            return;
        }
    }
}
