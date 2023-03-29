﻿using AvansDevOps.BacklogItemState;
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
        public string Description { get; set; }
        public List<Activity> Activities { get; private set; }
        public Developer? _developer { get; private set; }

        // State pattern
        public IBacklogItemState State { get; private set; }

        public BacklogItem(string DefinitionOfDone, string Description)
        {
            this.DefinitionOfDone = DefinitionOfDone;
            this.Description = Description;
            Activities = new();
            State = new TodoState(this);
        }

        public void AddActivity(Activity activity)
        {
            Activities.Add(activity);
        }

        public void RemoveActivity(Activity activity)
        {
            Activities.Remove(activity);
        }

        public int NotifyTesters()
        {
            if (notificationCallback != null) 
            { 
                return notificationCallback("Ticket is done for testing", typeof(Tester)); 
            }
            return 0;
        }
        public void AssignDeveloper(Developer developer) => _developer = developer;

        // State methods

        public int NotifyScrumMaster()
        {
            if (notificationCallback != null) 
            { 
                return notificationCallback("Ticket is rejected and put back in todo", typeof(ScrumMaster)); 
            }
            return 0;
        public void StartTask() {
            if (_developer is null)
            {
                Console.WriteLine("No Developer assigned yet!");
                return;
            }
            State.StartTask();
        }
        public void FinishTask() => State.FinishTask();
        public void StartTesting() => State.StartTesting();
        public void SendTestRapport(bool passed) => State.SendTestRapport(passed);
        public void EvaluateTestRapport(bool passed) => State.EvaluateTestRapport(passed);
        public void InvalidateTask() => State.InvalidateTask();

        public void UpdateState(IBacklogItemState newState)
        {
            State = newState;
        }
    }
}
