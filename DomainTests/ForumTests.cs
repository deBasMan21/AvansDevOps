using AvansDevOps;
using AvansDevOps.ForumComposite;
using AvansDevOps.SprintAbstraction;
using AvansDevOps.UserAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainTests
{
    public class ForumTests
    {
        [Fact]
        public void ForumShouldCloseWhenTicketIsClosed()
        {
            // Arrange
            Developer dev = new Developer("");
            dev.AddNotificationPreference(AvansDevOps.Enums.NotificationType.EMAIL);

            BacklogItem item = new BacklogItem("", "");
            item.AssignDeveloper(dev);

            FeedbackSprint sprint = new FeedbackSprint("", DateTime.Now, DateTime.Now);
            sprint.AssignScrumMaster(new ScrumMaster(""));
            sprint.SprintBacklog.Add(item);
            sprint.StartSprint();

            item.StartTask();
            item.FinishTask();
            item.StartTesting();
            item.SendTestRapport(true);
            item.EvaluateTestRapport(true);

            // Act
            var firstForumMessage = new ForumMessageComponent("testMessage", new Developer(""));
            var secondForumMessage = new ForumMessageComponent("testMessage2", new Developer(""));

            item.Forum?.AddMessage(firstForumMessage);

            sprint.FinishSprint();
            sprint.ReviewSprint(true);

            item.Forum?.GetComponents().FirstOrDefault()?.AddMessage(secondForumMessage);

            var forum = item.Forum;
            var firstMessage = forum?.GetComponents().FirstOrDefault();
            var secondMessage = firstMessage?.GetComponents().FirstOrDefault();

            // Assert
            Assert.NotNull(forum);
            Assert.NotNull(firstMessage);
            Assert.Null(secondMessage);

            Assert.IsType<ForumMessageComponent>(firstMessage);

            Assert.Equal(1, forum?.GetComponents().Count());

            Assert.Equal(firstForumMessage.message, firstMessage?.GetMessage());
        }

        [Fact]
        public void TurnMessageIntoThread()
        {
            // Arrange
            BacklogItem item = new BacklogItem("", "");
            item.AssignDeveloper(new Developer(""));

            item.StartTask();
            item.FinishTask();
            item.StartTesting();
            item.SendTestRapport(true);
            item.EvaluateTestRapport(true);

            // Act
            var firstForumMessage = new ForumMessageComponent("testMessage", new Developer(""));
            var secondForumMessage = new ForumMessageComponent("testMessage2", new Developer(""));

            item.Forum?.AddMessage(firstForumMessage);
            item.Forum?.GetComponents().FirstOrDefault()?.AddMessage(secondForumMessage);

            var forum = item.Forum;
            var firstMessage = forum?.GetComponents().FirstOrDefault();
            var secondMessage = firstMessage?.GetComponents().FirstOrDefault();

            // Assert
            Assert.NotNull(forum);
            Assert.NotNull(firstMessage);
            Assert.NotNull(secondMessage);

            Assert.IsType<ForumThreadComponent>(firstMessage);
            Assert.IsType<ForumMessageComponent>(secondMessage);

            Assert.Equal(1, forum?.GetComponents().Count());
            Assert.Equal(1, firstMessage?.GetComponents().Count());

            Assert.Equal(firstForumMessage.message, firstMessage?.GetMessage());
            Assert.Equal(secondForumMessage.message, secondMessage?.GetMessage());
        }
    }
}
