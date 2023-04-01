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
    public abstract class Sprint : ISprintStateHolder, IPublisher
    {
        public string Name { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public LeadDeveloper? LeadDeveloper { get; private set; }
        public ScrumMaster? ScrumMaster { get; private set; }
        public List<User> Developers { get; private set; }
        public Backlog SprintBacklog { get; private set; }

        public ISprintState CurrentState { get; private set; }

        protected Sprint(
            string Name, 
            DateTime StartDate, 
            DateTime EndDate
        ){
            this.Name = Name;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.SprintBacklog = new Backlog(Notify);
            this.Developers = new();
            CurrentState = new CreatedSprintState(this);
        }
        public void AddDeveloper(User developer)
        {
            Developers.Add(developer);

            if (developer is Tester tester) { RegisterSubscriber(tester); }
        }
        public void RemoveDeveloper(User developer)
        {
            Developers.Remove(developer);

            if (developer is Tester tester) { RemoveSubscriber(tester); }
        }

        public void AssignLeadDeveloper(LeadDeveloper lead) => LeadDeveloper = lead;
        public void AssignScrumMaster(ScrumMaster master) => ScrumMaster = master;


        // Sprint state update functions
        public void StartSprint() => CurrentState.StartSprint();
        public void FinishSprint() => CurrentState.FinishSprint();
        public void ReviewSprint(bool approvedDeployement = false) => CurrentState.ReviewSprint(approvedDeployement);

        public void UpdateSprintState(ISprintState state) => CurrentState = state;


        // Notification logic - IPublisher Interface
        private readonly List<ISubscriber> subscribers = new();

        public void RegisterSubscriber(ISubscriber Subscriber) => subscribers.Add(Subscriber);

        public void RemoveSubscriber(ISubscriber Subscriber) => subscribers.Remove(Subscriber);

        public virtual int Notify(string message, Type? userType)
        {
            if (userType == typeof(ScrumMaster) && ScrumMaster is not null)
            {
                return ScrumMaster.ReceiveUpdate(message);
            } else if (userType == typeof(Tester))
            {
                return subscribers.Select(u => u.ReceiveUpdate(message)).Sum();
            }

            return 0;
        }

        public void CloseTasks() => SprintBacklog.CloseTasks();
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
