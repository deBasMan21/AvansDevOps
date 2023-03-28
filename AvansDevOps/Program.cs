using AvansDevOps;
using AvansDevOps.SprintAbstraction;
using AvansDevOps.UserAbstraction;

Sprint sprint = new ReleaseSprint(
    Name: "", 
    StartDate: DateTime.Now, 
    EndDate: DateTime.Now, 
    leadDeveloper: new LeadDeveloper(Name: "John Doe"),
    scrumMaster: new ScrumMaster(Name: "Kapitein Haak"),
    developers: new List<User>()
);

BacklogItem item = new BacklogItem(defenitionOfDone: "done", developer: new Developer(Name: "Koen van Hees"));

sprint.sprintBacklog.Add(item);

Tester tester = new Tester("Tester");
sprint.AddDeveloper(tester);
tester.AddNotificationPreference(AvansDevOps.Enums.NotificationType.SLACK);

item.StartTask();
item.FinishTask();
item.TestTask(false);
item.StartTask();
item.FinishTask();
item.TestTask(true);
item.CloseTask();