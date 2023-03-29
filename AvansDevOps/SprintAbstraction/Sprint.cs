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
        public LeadDeveloper? LeadDeveloper { get; private set; }
        public ScrumMaster? ScrumMaster { get; private set; }
        public List<Developer> Developers { get; private set; }
        public Backlog SprintBacklog { get; private set; }

        public ISprintState CurrentState { get; private set; }

        public Sprint(
            string Name, 
            DateTime StartDate, 
            DateTime EndDate
        ){
            this.Name = Name;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.Developers = new();
            this.SprintBacklog = new();
            CurrentState = new CreatedSprintState(this);
        }

        public void AddDeveloper(Developer developer) => Developers.Add(developer);
        public void RemoveDeveloper(Developer developer) => Developers.Remove(developer);

        public void AssignLeadDeveloper(LeadDeveloper lead) => LeadDeveloper = lead;
        public void AssignScrumMaster(ScrumMaster master) => ScrumMaster = master;


        // Sprint state update functions
        public void StartSprint() => CurrentState.StartSprint();
        public void FinishSprint() => CurrentState.FinishSprint();
        public void ReviewSprint(bool approvedDeployement = false) => CurrentState.ReviewSprint(approvedDeployement);


        // ISprintStateHolder Interface
        public void UpdateSprintState(ISprintState state) => CurrentState = state;
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
