using AvansDevOps.SprintAbstraction;
using AvansDevOps.UserAbstraction;
using AvansDevOps;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainTests.NotificationTests
{
    public class ScrumMasterNotificationTest
    {
        // Multiple tests for notifications
        [Theory]
        // Fail test so phase should receive notification
        [InlineData(true, 1)]
        // Succeed test phase so should receive no notification
        [InlineData(false, 0)]
        public void ScrumMasterNotificationOnTestTicket(bool shouldCallNotification, int notificationCount)
        {
            bool calledNotification = false;

            // Arrange
            var scrumMasterMock = new Mock<ScrumMaster>("Kapitein Haak");
            scrumMasterMock.Setup(s => s.ReceiveUpdate(It.IsAny<string>())).Callback(() => calledNotification = true).Returns(1);

            ScrumMaster scrumMaster = scrumMasterMock.Object;
            scrumMaster.AddNotificationPreference(AvansDevOps.Enums.NotificationType.SLACK);

            Sprint sprint = new ReleaseSprint(
                "",
                DateTime.Now,
                DateTime.Now
            );

            sprint.AssignScrumMaster(scrumMaster);

            BacklogItem item = new BacklogItem(DefinitionOfDone: "done", Description: "hi");
            item.AssignDeveloper(new Developer(Name: "John Doe"));
            sprint.SprintBacklog.Add(item);

            item.StartTask();
            item.FinishTask();
            item.StartTesting();

            // Act
            int result = item.SendTestRapport(!shouldCallNotification);

            // Assert
            Assert.Equal(notificationCount, result);
            Assert.Equal(shouldCallNotification, calledNotification);
        }
    }
}
