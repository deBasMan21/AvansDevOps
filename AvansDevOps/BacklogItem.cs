using AvansDevOps.BacklogItemState;
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
        string DefenitionOfDone { get; set; }
        private List<Activity> Activities { get; set; }
        private Developer Developer;
        private Func<string, Type, int>? notificationCallback;

        // State pattern
        private IBacklogItemState _state;

        public BacklogItem(string defenitionOfDone, Developer developer)
        {
            DefenitionOfDone = defenitionOfDone;
            Activities = new List<Activity>();
            _state = new TodoState(this);
            Developer = developer;
        }

        public void SetNotificationCallback(Func<string, Type, int>? notificationCallback) => this.notificationCallback = notificationCallback;

        public void AssignDeveloper(Developer developer) => this.Developer = developer;

        public void StartTask() => _state.StartTask();

        public int FinishTask() => _state.FinishTask();

        public void TestTask(bool success) => _state.TestTask(success);

        public void CloseTask() => _state.CloseTask();

        public void InvalidateTask() => _state.InvalidateTask();

        public void AddActivity(Activity activity) => Activities.Add(activity);

        public void RemoveActivity(Activity activity) => Activities.Remove(activity);

        public void UpdateState(IBacklogItemState newState) => _state = newState;

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
    }
}
