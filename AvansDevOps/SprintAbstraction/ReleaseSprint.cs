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
        protected IDeploymentState deploymentState { get; private set; }
        public ReleaseSprint(
            string Name, 
            DateTime StartDate, 
            DateTime EndDate, 
            LeadDeveloper leadDeveloper, 
            ScrumMaster scrumMaster, 
            List<Developer> developers,
            Backlog sprintBacklog
            ) : base(Name, StartDate, EndDate, leadDeveloper, scrumMaster, developers, sprintBacklog)
        {
            deploymentState = new NotReadyToDeploy(this);
        }

        public void UpdateDeploymentState(IDeploymentState state) => deploymentState = state;
        public void ApproveDeployment() => deploymentState.ApproveDeployment();
        public void StartDeployment() => deploymentState.StartDeployment();
        public void CancelDeployment() => deploymentState.CancelDeployment();
        public void FailDeployment() => deploymentState.FailDeployment();
        public void RestartDeployment() => deploymentState.RestartDeployment();
    }
}
