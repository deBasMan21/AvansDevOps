using AvansDevOps;
using AvansDevOps.SprintAbstraction;
using AvansDevOps.UserAbstraction;

ScrumMaster scrumMaster = new ScrumMaster(Name: "Kapitein Haak");

ReleaseSprint sprint = new ReleaseSprint(
    Name: "", 
    StartDate: DateTime.Now, 
    EndDate: DateTime.Now 
);

sprint.AssignLeadDeveloper(new(Name: "John Doe"));
sprint.AssignScrumMaster(scrumMaster);

Developer dev = new Developer(Name: "Koen van Hees");
sprint.StartSprint();

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

sprint.FinishSprint();
sprint.ReviewSprint(approvedDeployement: true);

bool pipelineSucceeded = sprint.StartDeployment(
        gitUrl: "https://github.com/deBasMan21/AvansDevOps",
        dependencies: new() { "xunit (2.4.2)", "Moq (4.18.4)" }, 
        buildType: ".NET Core build", 
        testFramework: "XUnit 2.4.2",
        analyseTool: "SonarQube",
        deploymentTarget: "Azure",
        utilityActions: new() { "UtilityAction1", "UtilityAction2" }
    );

sprint.FinishDeployment(succeeded: pipelineSucceeded);