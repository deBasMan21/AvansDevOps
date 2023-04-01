using AvansDevOps.ForumComposite;
using AvansDevOps.UserAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainTests.NotificationTests
{
    public class ForumNotificationTests
    {
        [Fact]
        public void CreatorShouldReceiveNotificationsFromPostsInThread()
        {
            // Arrange
            User creator = new Developer("creator");
            creator.AddNotificationPreference(AvansDevOps.Enums.NotificationType.EMAIL);

            ForumThreadComponent initialMessage = new ForumThreadComponent(new ForumMessageComponent("initial message", creator));

            // Act
            int result = initialMessage.AddMessage(new ForumMessageComponent("new post", new Developer("other")));

            // Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void UserThatPostsInThreadShouldReceiveUpdatesAfterPost()
        {
            // Arrange
            User creator = new Developer("creator");
            creator.AddNotificationPreference(AvansDevOps.Enums.NotificationType.EMAIL);

            ForumThreadComponent initialMessage = new ForumThreadComponent(new ForumMessageComponent("initial message", new Developer(""))); 

            // Act
            int postResult = initialMessage.AddMessage(new ForumMessageComponent("new post", creator));
            int result = initialMessage.AddMessage(new ForumMessageComponent("new post", new Developer("")));

            // Assert
            Assert.Equal(1, result);
            Assert.Equal(0, postResult);
        }

        [Fact]
        public void CreatorOfMessageThatIsBecomingAThreadShouldReceiveUpdatesFromThread()
        {
            // The user that created a message that is now being turned into a thread should receive a message
            // Arrange
            User creator = new Developer("creator");
            creator.AddNotificationPreference(AvansDevOps.Enums.NotificationType.EMAIL);

            ForumThreadComponent initialMessage = new ForumThreadComponent(new ForumMessageComponent("initial message", creator));
            initialMessage.AddMessage(new ForumMessageComponent("new post", creator));

            // Act
            int? result = initialMessage.GetComponents().FirstOrDefault()?.AddMessage(new ForumMessageComponent("", new Developer("")));

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result);
        }
    }
}
