using AvansDevOps.BacklogItemState;
using AvansDevOps.ForumComposite;
using AvansDevOps.NotificationObserver;
using AvansDevOps.SprintAbstraction;
using AvansDevOps.UserAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps
{
    public class BacklogItem
    {
        public string DefinitionOfDone { get; private set; }
        public string Description { get; private set; }
        public List<Activity> Activities { get; private set; }
        public Developer? _developer { get; private set; }
        public Func<string, Type, int>? notificationCallback { get; private set; }
        public IForumComponent? Forum { get; private set; }

        // State pattern
        public IBacklogItemState State { get; set; }

        public BacklogItem(string DefinitionOfDone, string Description)
        {
            this.DefinitionOfDone = DefinitionOfDone;
            this.Description = Description;
            Activities = new();
            State = new TodoState(this);
        }

        public void SetNotificationCallback(Func<string, Type, int>? notificationCallback) => this.notificationCallback = notificationCallback;

        public void AddActivity(Activity activity) => Activities.Add(activity);

        public void RemoveActivity(Activity activity) => Activities.Remove(activity);

        public void AssignDeveloper(Developer developer)
        {
            _developer = developer;

            if (Forum == null && _developer != null)
            {
                Forum = new ForumThreadComponent(new ForumMessageComponent("", _developer));
            }
        }

        // Notifications
        public int NotifyTesters()
        {
            if (notificationCallback != null) 
            { 
                return notificationCallback("Ticket is done for testing", typeof(Tester)); 
            }
            return 0;
        }

        public int NotifyScrumMaster()
        {
            if (notificationCallback != null)
            {
                return notificationCallback("Ticket is rejected and put back in todo", typeof(ScrumMaster));
            }
            return 0;
        }

        // Update item state
        public void StartTask() {
            if (_developer is null)
            {
                Console.WriteLine("No Developer assigned yet!");
                return;
            }
            State.StartTask();
        }
        public int FinishTask() => State.FinishTask();
        public void StartTesting() => State.StartTesting();
        public int SendTestRapport(bool passed) => State.SendTestRapport(passed);
        public void EvaluateTestRapport(bool passed) => State.EvaluateTestRapport(passed);
        public void InvalidateTask() => State.InvalidateTask();
        public void CloseTask() => State.CloseTask();

        public void UpdateState(IBacklogItemState newState) => State = newState;
    }
}
