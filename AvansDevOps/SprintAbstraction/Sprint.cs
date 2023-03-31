using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansDevOps.NotificationObserver;
using AvansDevOps.SprintDeploymentState;
using AvansDevOps.SprintState;
using AvansDevOps.UserAbstraction;

namespace AvansDevOps.SprintAbstraction
{
    public abstract class Sprint : ISprintStateHolder, IPublisher<Tester>
    {
        public string Name { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public LeadDeveloper? LeadDeveloper { get; private set; }
        public ScrumMaster? ScrumMaster { get; private set; }
        public List<Developer> Developers { get; private set; }
        public Backlog SprintBacklog { get; private set; }

        public ISprintState CurrentState { get; private set; }

        protected Sprint(
            string Name, 
            DateTime StartDate, 
            DateTime EndDate
            Backlog sprintBacklog
        ){
            this.Name = Name;
            this.StartDate = StartDate;
            this.leadDeveloper = leadDeveloper;
            this.scrumMaster = scrumMaster;
            this.developers = developers;
            this.sprintBacklog = new Backlog(Notify);
            currentState = new CreatedSprintState(this);
            this.Developers = new();
            this.SprintBacklog = new();
            CurrentState = new CreatedSprintState(this);
            currentState = new CreatedSprintState(this);
        }
        public void AddDeveloper(User developer)
        {
            developers.Add(developer);

            if (developer is Tester tester) { RegisterSubscriber(tester); }
        }
        public void RemoveDeveloper(User developer)
        {
            developers.Remove(developer);

            if (developer is Tester tester) { RemoveSubscriber(tester); }
        }
        public void AddDeveloper(Developer developer) => Developers.Add(developer);
        public void RemoveDeveloper(Developer developer) => Developers.Remove(developer);

        public void AssignLeadDeveloper(LeadDeveloper lead) => LeadDeveloper = lead;
        public void AssignScrumMaster(ScrumMaster master) => ScrumMaster = master;

        public void RemoveDeveloper(Developer developer) => developers.Remove(developer);

        // Sprint state update functions
        public void StartSprint() => CurrentState.StartSprint();
        public void FinishSprint() => CurrentState.FinishSprint();
        public void ReviewSprint(bool approvedDeployement = false) => CurrentState.ReviewSprint(approvedDeployement);


        public void UpdateSprintState(ISprintState state) => currentState = state;

        // Notification logic - IPublisher Interface
        private readonly List<Tester> subscribers = new List<Tester>();

        public void RegisterSubscriber(Tester Subscriber) => subscribers.Add(Subscriber);

        public void RemoveSubscriber(Tester Subscriber) => subscribers.Remove(Subscriber);

        public virtual int Notify(string message, Type userType)
        {
            if (userType == typeof(ScrumMaster))
            {
                return scrumMaster.ReceiveUpdate(message);
            } else if (userType == typeof(Tester))
            {
                return subscribers.Select(u => u.ReceiveUpdate(message)).Sum();
            }

            return 0;
        }
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
