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
        public void CreateThreadFromExistingMessage()
        {
            // Arrange
            BacklogItem item = new BacklogItem("", "");
            item.AssignDeveloper(new Developer(""));

            FeedbackSprint sprint = new FeedbackSprint("", DateTime.Now, DateTime.Now);
            sprint.AssignScrumMaster(new ScrumMaster(""));
            sprint.SprintBacklog.Add(item);
            sprint.StartSprint();

            item.StartTask();
            item.FinishTask();
            item.StartTesting();
            item.SendTestRapport(true);
            item.EvaluateTestRapport(true);


            sprint.FinishSprint();
            sprint.ReviewSprint(true);
            // Act

            // Assert
        }
    }
}
