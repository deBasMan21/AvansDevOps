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
    public class BacklogItem: IBacklogItem
    {
        string _defenitionOfDone { get; set; }
        private List<Activity> _activities { get; set; }
        private User _developer;
        private Func<string, bool>? notificationCallback;

        // State pattern
        private IBacklogItemState _state;

        public BacklogItem(string defenitionOfDone, User developer)
        {
            _defenitionOfDone = defenitionOfDone;
            _activities = new List<Activity> { };
            _state = new TodoState(this);
            _developer = developer;
        }

        public void SetNotificationCallback(Func<string, bool> notificationCallback) => this.notificationCallback = notificationCallback;

        public void StartTask()
        {
            _state.StartTask();
        }

        public void FinishTask()
        {
            _state.FinishTask();
            NotifyTesters();
        }

        public void TestTask(bool success)
        {
            _state.TestTask(success);
        }

        public void CloseTask()
        {
            _state.CloseTask();
        }

        public void InvalidateTask()
        {
            _state.InvalidateTask();
        }

        public void AddActivity(Activity activity)
        {
            _activities.Add(activity);
        }

        public void RemoveActivity(Activity activity)
        {
            _activities.Remove(activity);
        }

        public void UpdateState(IBacklogItemState newState)
        {
            _state = newState;
        }

        public void NotifyTesters()
        {
            if (notificationCallback != null) { notificationCallback("Ticket is done for testing"); }
        }
    }
}
