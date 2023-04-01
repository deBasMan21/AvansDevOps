using AvansDevOps.UserAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainTests.NotificationTests
{
    public class NotificationTypeTests
    {
        [Fact]
        public void MultipleNotificationTypesShouldSendMultipleNotifications()
        {
            // Arrange
            User user = new Developer("name");
            user.AddNotificationPreference(AvansDevOps.Enums.NotificationType.EMAIL);
            user.AddNotificationPreference(AvansDevOps.Enums.NotificationType.SLACK);

            // Act
            int notificationsSent = user.ReceiveUpdate("Notification");

            // Assert
            Assert.Equal(2, notificationsSent);
        }

        [Fact]
        public void OneNotificationTypeShouldSendOneNotification()
        {
            // Arrange
            User user = new Developer("name");
            user.AddNotificationPreference(AvansDevOps.Enums.NotificationType.EMAIL);

            // Act
            int notificationsSent = user.ReceiveUpdate("Notification");

            // Assert
            Assert.Equal(1, notificationsSent);
        }

        [Fact]
        public void NoNotificationTypeShouldSendNoNotification()
        {
            // Arrange
            User user = new Developer("name");

            // Act
            int notificationsSent = user.ReceiveUpdate("Notification");

            // Assert
            Assert.Equal(0, notificationsSent);
        }

        [Fact]
        public void DoubleNotificationTypeShouldSendOneNotification()
        {
            // Arrange
            User user = new Developer("name");
            user.AddNotificationPreference(AvansDevOps.Enums.NotificationType.EMAIL);
            user.AddNotificationPreference(AvansDevOps.Enums.NotificationType.EMAIL);

            // Act
            int notificationsSent = user.ReceiveUpdate("Notification");

            // Assert
            Assert.Equal(1, notificationsSent);
        }
    }
}
