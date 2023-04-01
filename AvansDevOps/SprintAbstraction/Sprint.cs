using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansDevOps.NotificationObserver;
using AvansDevOps.ReportFactory;
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
        public List<User> Developers { get; private set; }
        public Backlog SprintBacklog { get; private set; }
        public ISprintState CurrentState { get; private set; }

        private ProductOwner? ProductOwner = null;
        private ReportFactoryHolder factoryHolder = new ReportFactoryHolder();

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
        public void AssignProductOwner(ProductOwner productOwner) => ProductOwner = productOwner;

        // Sprint state update functions
        public void StartSprint() => CurrentState.StartSprint();
        public void FinishSprint() => CurrentState.FinishSprint();
        public void ReviewSprint(bool approvedDeployement = false) => CurrentState.ReviewSprint(approvedDeployement);

        public void UpdateSprintState(ISprintState state) => CurrentState = state;


        // Notification logic - IPublisher Interface
        private readonly List<Tester> subscribers = new List<Tester>();

        public void RegisterSubscriber(Tester Subscriber) => subscribers.Add(Subscriber);

        public void RemoveSubscriber(Tester Subscriber) => subscribers.Remove(Subscriber);

        public virtual int Notify(string message, Type? userType)
        {
            if (userType == typeof(ScrumMaster) && ScrumMaster is not null)
            {
                return ScrumMaster.ReceiveUpdate(message);
            } else if (userType == typeof(Tester))
            {
                return subscribers.Select(u => u.ReceiveUpdate(message)).Sum();
            } else if (userType == typeof(ProductOwner) && ProductOwner  is not null)
            {
                return ProductOwner.ReceiveUpdate(message);
            }

            return 0;
        }

        public IReport CreateReport(ReportType type, string content, string? header = null, string? footer = null)
        {
            IReportFactory factory = factoryHolder.CreateReportFactory(type);
            if (header is not null) { factory.AddCustomHeader(header); }
            if (footer is not null) { factory.AddCustomFooter(footer); }
            return factory.CreateReport(content);
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
