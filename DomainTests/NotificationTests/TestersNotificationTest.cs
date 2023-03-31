using AvansDevOps;
using AvansDevOps.SprintAbstraction;
using AvansDevOps.UserAbstraction;
using Microsoft.VisualStudio.TestPlatform.Common.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace DomainTests.NotificationTests
{
    public class TestersNotificationTest
    {
        [Fact]
        public void SingleTesterShouldReceiveNotificationWhenTicketGoesToReadyForTesting()
        {
            string messageObj = "";
            Type? typeObj = null;

            // Arrange
            var mock = new Mock<ReleaseSprint>(
                "",
                DateTime.Now,
                DateTime.Now
            );
            mock.CallBase = true;
            mock.Setup(c => 
                c.Notify(
                    It.IsAny<string>(), 
                    It.IsAny<Type>()
                )
            ).Callback((string message, Type type) => { 
                messageObj = message; 
                typeObj = type; 
            }).Returns(1);

            Sprint sprint = mock.Object;

            BacklogItem item = new BacklogItem(DefinitionOfDone: "done", Description: "hi");
            item.AssignDeveloper(new Developer(Name: "John Doe"));
            sprint.SprintBacklog.Add(item);

            Tester tester = new Tester("Tester");
            sprint.AddDeveloper(tester);
            tester.AddNotificationPreference(AvansDevOps.Enums.NotificationType.SLACK);

            item.StartTask();

            // Act
            int result = item.FinishTask();

            // Assert
            Assert.Equal(1, result);
            Assert.NotNull(typeObj);
            Assert.Equal(typeof(Tester), typeObj);
            Assert.NotEmpty(messageObj);
        }

        [Fact]
        public void MultipleTestersShouldReceiveNotificationWhenTicketGoesToReadyForTesting()
        {
            // Arrange
            string messageObj = "";
            Type? typeObj = null;

            // Arrange
            var mock = new Mock<ReleaseSprint>(
                "",
                DateTime.Now,
                DateTime.Now
            );
            mock.CallBase = true;
            mock.Setup(c =>
                c.Notify(
                    It.IsAny<string>(),
                    It.IsAny<Type>()
                )
            ).Callback((string message, Type type) => {
                messageObj = message;
                typeObj = type;
            }).Returns(4);

            Sprint sprint = mock.Object;

            BacklogItem item = new BacklogItem(DefinitionOfDone: "done", Description: "hi");
            item.AssignDeveloper(new Developer(Name: "John Doe"));
            sprint.SprintBacklog.Add(item);

            Tester tester = new Tester("Tester");
            sprint.AddDeveloper(tester);
            tester.AddNotificationPreference(AvansDevOps.Enums.NotificationType.SLACK);
            tester.AddNotificationPreference(AvansDevOps.Enums.NotificationType.EMAIL);

            Tester tester2 = new Tester("Tester2");
            sprint.AddDeveloper(tester2);
            tester2.AddNotificationPreference(AvansDevOps.Enums.NotificationType.SLACK);

            Tester tester3 = new Tester("Tester3");
            sprint.AddDeveloper(tester3);
            tester3.AddNotificationPreference(AvansDevOps.Enums.NotificationType.EMAIL);

            item.StartTask();

            // Act
            int result = item.FinishTask();

            // Assert
            Assert.Equal(4, result);
            Assert.NotNull(typeObj);
            Assert.Equal(typeof(Tester), typeObj);
            Assert.NotEmpty(messageObj);
        }

        [Fact]
        public void SingleTesterShouldNotReceiveNotificationAfterRemovingFromTicket()
        {

            // Arrange
            string messageObj = "";
            Type? typeObj = null;

            // Arrange
            var mock = new Mock<ReleaseSprint>(
                "",
                DateTime.Now,
                DateTime.Now
            );
            mock.CallBase = true;
            mock.Setup(c =>
                c.Notify(
                    It.IsAny<string>(),
                    It.IsAny<Type>()
                )
            ).Callback((string message, Type type) => {
                messageObj = message;
                typeObj = type;
            }).Returns(0);

            Sprint sprint = mock.Object;

            BacklogItem item = new BacklogItem(DefinitionOfDone: "done", Description: "hi");
            item.AssignDeveloper(new Developer(Name: "John Doe"));
            sprint.SprintBacklog.Add(item);

            Tester tester = new Tester("Tester");
            sprint.AddDeveloper(tester);
            tester.AddNotificationPreference(AvansDevOps.Enums.NotificationType.SLACK);
            tester.AddNotificationPreference(AvansDevOps.Enums.NotificationType.EMAIL);

            sprint.RemoveDeveloper(tester);

            item.StartTask();

            // Act
            int result = item.FinishTask();

            // Assert
            Assert.Equal(0, result);
            Assert.NotNull(typeObj);
            Assert.Equal(typeof(Tester), typeObj);
            Assert.NotEmpty(messageObj);
        }
    }
}
