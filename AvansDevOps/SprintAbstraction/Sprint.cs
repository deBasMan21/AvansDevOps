using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansDevOps.SprintDeploymentState;
using AvansDevOps.SprintState;
using AvansDevOps.UserAbstraction;

namespace AvansDevOps.SprintAbstraction
{
    public abstract class Sprint : ISprintStateHolder
    {
        public string Name { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public LeadDeveloper leadDeveloper { get; private set; }
        public ScrumMaster scrumMaster { get; private set; }
        public List<Developer> developers { get; private set; }
        public Backlog sprintBacklog { get; private set; }

        public ISprintState currentState { get; private set; }

        public Sprint(
            string Name, 
            DateTime StartDate, 
            DateTime EndDate, 
            LeadDeveloper leadDeveloper, 
            ScrumMaster scrumMaster,
            List<Developer> developers,
            Backlog sprintBacklog
        ){
            this.Name = Name;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.leadDeveloper = leadDeveloper;
            this.scrumMaster = scrumMaster;
            this.developers = developers;
            this.sprintBacklog = sprintBacklog;
            currentState = new CreatedSprintState(this);
        }

        public void AddDeveloper(Developer developer) => developers.Add(developer);
        public void RemoveDeveloper(Developer developer) => developers.Remove(developer);

        // Sprint state update functions
        public void StartSprint() => currentState.StartSprint();
        public void FinishSprint() => currentState.FinishSprint();
        public void ReviewSprint() => currentState.ReviewSprint();


        // ISprintStateHolder Interface
        public void UpdateSprintState(ISprintState state) => currentState = state;
    }

    public interface ISprintStateHolder
    {
        void UpdateSprintState(ISprintState state);
    }

    public interface IDeploymentStateHolder
    {
        void UpdateDeploymentState(IDeploymentState state);
    }
}
