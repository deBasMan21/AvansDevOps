using AvansDevOps;
using AvansDevOps.ForumComposite;
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

BacklogItem item = new BacklogItem(DefinitionOfDone: "done", Description: "test");
item.AssignDeveloper(dev);

sprint.sprintBacklog.Add(item);

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

User user = new Developer("hoi");
user.AddNotificationPreference(AvansDevOps.Enums.NotificationType.SLACK);

User user2 = new Developer("hoi2");
user2.AddNotificationPreference(AvansDevOps.Enums.NotificationType.EMAIL);

User user3 = new Developer("hoi3");
user3.AddNotificationPreference(AvansDevOps.Enums.NotificationType.EMAIL);

ForumMessageComponent message = new ForumMessageComponent("test", user);
ForumThreadComponent forum = new ForumThreadComponent(message);
forum.AddMessage(new ForumMessageComponent("test2", user2));
forum.AddMessage(new ForumMessageComponent("test3", user3));
forum.AddMessage(new ForumMessageComponent("test4", user));

int? result = forum.GetComponents().FirstOrDefault()?.AddMessage(new ForumMessageComponent("new message", user3));
Console.WriteLine(result);