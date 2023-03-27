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
        protected IDeploymentState deploymentState;
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
            deploymentState = new ReadyToDeployState(this);
        }

        public void UpdateDeploymentState(IDeploymentState state) => deploymentState = state;

        public override void StartClosedSprintAction() => deploymentState.StartDeployment();
    }
}
