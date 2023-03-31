using AvansDevOps;
using AvansDevOps.SprintAbstraction;
using AvansDevOps.UserAbstraction;

ScrumMaster scrumMaster = new ScrumMaster(Name: "Kapitein Haak");

Sprint sprint = new ReleaseSprint(
    Name: "", 
    StartDate: DateTime.Now, 
    EndDate: DateTime.Now 
);

sprint.AssignLeadDeveloper(new(Name: "John Doe"));
sprint.AssignScrumMaster(scrumMaster);

Developer dev = new Developer(Name: "Koen van Hees");

BacklogItem item = new BacklogItem(DefinitionOfDone: "done", Description: "test");
item.AssignDeveloper(dev);

sprint.SprintBacklog.Add(item);

sprint.AddDeveloper(dev);

Tester tester = new Tester("Tester");
sprint.AddDeveloper(tester);
tester.AddNotificationPreference(AvansDevOps.Enums.NotificationType.SLACK);

scrumMaster.AddNotificationPreference(AvansDevOps.Enums.NotificationType.EMAIL);

item.StartTask();
item.FinishTask();
item.StartTesting();
item.SendTestRapport(true);
item.EvaluateTestRapport(false);