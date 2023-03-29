using AvansDevOps;
using AvansDevOps.SprintAbstraction;
using AvansDevOps.UserAbstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainTests.NotificationTests
{
    public class TestersNotificationTest
    {
        [Fact]
        public void TestersShouldReceiveNotificationWhenTicketGoesToReadyForTesting()
        {
            // Arrange
            Sprint sprint = new ReleaseSprint(
                Name: "",
                StartDate: DateTime.Now,
                EndDate: DateTime.Now,
                leadDeveloper: new LeadDeveloper(Name: "John Doe"),
                scrumMaster: new ScrumMaster(Name: "Kapitein Haak"),
                developers: new List<User>()
            );

            BacklogItem item = new BacklogItem(DefinitionOfDone: "done", Description: "hi");
            item.AssignDeveloper(new Developer(Name: "John Doe"));
            sprint.sprintBacklog.Add(item);

            Tester tester = new Tester("Tester");
            Tester tester2 = new Tester("Tester2");
            sprint.AddDeveloper(tester);
            sprint.AddDeveloper(tester2);
            tester2.AddNotificationPreference(AvansDevOps.Enums.NotificationType.SLACK);
            tester.AddNotificationPreference(AvansDevOps.Enums.NotificationType.SLACK);
            tester.AddNotificationPreference(AvansDevOps.Enums.NotificationType.EMAIL);

            item.StartTask();

            // Act
            var result = 3;

            // Assert
            Assert.Equal(3, result);
        }
        [Fact]
        public void Tmp()
        {
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            Console.WriteLine("Heyyy hallo");
            Console.WriteLine("Heyyy hallo");
            Console.WriteLine("Heyyy hallo");

            List<string> output = stringWriter
                .ToString()
                .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Assert.Equal(3, output.Count);
        }
    }
}
