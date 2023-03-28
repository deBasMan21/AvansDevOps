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
    public abstract class Sprint : ISprintStateHolder, IPublisher<User>
    {
        public string Name { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public LeadDeveloper leadDeveloper { get; private set; }
        public ScrumMaster scrumMaster { get; private set; }
        public List<User> developers { get; private set; }
        public Backlog sprintBacklog { get; private set; }

        public ISprintState currentState { get; private set; }

        public Sprint(
            string Name, 
            DateTime StartDate, 
            DateTime EndDate, 
            LeadDeveloper leadDeveloper, 
            ScrumMaster scrumMaster,
            List<User> developers
        ){
            this.Name = Name;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.leadDeveloper = leadDeveloper;
            this.scrumMaster = scrumMaster;
            this.developers = developers;
            this.sprintBacklog = new Backlog(Notify);
            currentState = new CreatedSprintState(this);
        }

        public void AddDeveloper(User developer)
        {
            developers.Add(developer);
            if (developer is Tester) { RegisterSubscriber(developer); }
        }
        public void RemoveDeveloper(User developer)
        {
            developers.Remove(developer);
            if (developer is Tester) { RemoveSubscriber(developer); }
            
        }

        // Sprint state update functions
        public void StartSprint() => currentState.StartSprint();
        public void FinishSprint() => currentState.FinishSprint();
        public void ReviewSprint() => currentState.ReviewSprint();


        // ISprintStateHolder Interface
        public void UpdateSprintState(ISprintState state) => currentState = state;

        // Notification logic - IPublisher Interface
        private List<User> subscribers = new List<User>();

        public void RegisterSubscriber(User Subscriber)
        {
            subscribers.Add(Subscriber);
        }

        public void RemoveSubscriber(User Subscriber)
        {
            subscribers.Remove(Subscriber);
        }

        public bool Notify(string message)
        {
            foreach (User user in subscribers)
            {
                user.ReceiveUpdate(message);
            }

            return true;
        }
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
