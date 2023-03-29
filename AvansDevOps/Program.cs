using AvansDevOps;
using AvansDevOps.SprintAbstraction;
using AvansDevOps.UserAbstraction;

ScrumMaster scrumMaster = new ScrumMaster(Name: "Kapitein Haak");

Sprint sprint = new ReleaseSprint(
    Name: "", 
    StartDate: DateTime.Now, 
    EndDate: DateTime.Now, 
    leadDeveloper: new LeadDeveloper(Name: "John Doe"),
    scrumMaster: scrumMaster,
    developers: new List<User>()
);

Developer dev = new Developer(Name: "Koen van Hees");

BacklogItem item = new BacklogItem(defenitionOfDone: "done", developer: dev);

sprint.sprintBacklog.Add(item);

sprint.AddDeveloper(dev);

Tester tester = new Tester("Tester");
sprint.AddDeveloper(tester);
tester.AddNotificationPreference(AvansDevOps.Enums.NotificationType.SLACK);

scrumMaster.AddNotificationPreference(AvansDevOps.Enums.NotificationType.EMAIL);

item.StartTask();
item.FinishTask();
item.TestTask(false);
item.StartTask();
item.FinishTask();
item.TestTask(true);
item.CloseTask();