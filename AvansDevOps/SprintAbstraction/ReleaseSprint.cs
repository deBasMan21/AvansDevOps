using AvansDevOps.SprintDeploymentState;
using AvansDevOps.UserAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.SprintAbstraction
{
    public class ReleaseSprint : Sprint, IDeploymentStateHolder
    {
        public IDeploymentState deploymentState { get; private set; }
        public ReleaseSprint(
            string Name, 
            DateTime StartDate, 
            DateTime EndDate
            ) : base(Name, StartDate, EndDate)
        {
            deploymentState = new NotReadyToDeploy(this);
        }

        public void UpdateDeploymentState(IDeploymentState state) => deploymentState = state;
        public void ApproveDeployment() => deploymentState.ApproveDeployment();
        public bool StartDeployment(string gitUrl, List<string> dependencies, string buildType, string testFramework, string analyseTool, string deploymentTarget, List<string> utilityActions) => deploymentState.StartDeployment(gitUrl, dependencies, buildType, testFramework, analyseTool, deploymentTarget, utilityActions);
        public int CancelDeployment() 
        { 
            deploymentState.CancelDeployment();

            string notificationString = "Deployment for release cancelled";
            int notificationCount = Notify(notificationString, typeof(ProductOwner));
            notificationCount += Notify(notificationString, typeof(ScrumMaster));
            return notificationCount;
        }
        public int FinishDeployment(bool succeeded)
        {
            deploymentState.FinishDeployment(succeeded);

            string notificationString = succeeded ? "Deployment for release succeeded" : "Deployment for release failed";
            int notificationCount = Notify(notificationString, typeof(ScrumMaster));
            if (succeeded) { notificationCount += Notify(notificationString, typeof(ScrumMaster)); }
            return notificationCount;
        }

        public void RestartDeployment() => deploymentState.RestartDeployment();
    }
}
