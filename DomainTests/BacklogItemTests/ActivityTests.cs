using AvansDevOps;
using AvansDevOps.BacklogItemState;
using AvansDevOps.UserAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainTests.BacklogItemTests
{
    public class ActivityTests
    {
        [Fact]
        public void Backlog_Item_Should_Finish_With_Zero_Activities()
        {
            // Arrange
            BacklogItem item = new(DefinitionOfDone: "This is the DoD", Description: "Description");
            Developer dev = new(Name: "dev");
            item.UpdateState(new DoingState(item));
            item.AssignDeveloper(dev);

            // Act
            item.FinishTask();

            // Assert
            Assert.True(item.State is ReadyForTestingState);
        }

        [Fact]
        public void Backlog_Item_Should_Finish_With_All_Finished_Activities()
        {
            // Arrange
            BacklogItem item = new(DefinitionOfDone: "This is the DoD", Description: "Description");
            Developer dev = new(Name: "dev");
            Activity activity = new(Task: "Activity1");
            activity.AssignDeveloper(dev);
            activity.FinishTask();
            Activity activity2 = new(Task: "Activity2");
            activity2.AssignDeveloper(dev);
            activity2.FinishTask();
            Activity activity3 = new(Task: "Activity3");
            activity3.AssignDeveloper(dev);
            activity3.FinishTask();

            item.AddActivity(activity);
            item.AddActivity(activity2);
            item.AddActivity(activity3);
            item.UpdateState(new DoingState(item));
            item.AssignDeveloper(dev);

            // Act
            item.FinishTask();

            // Assert
            Assert.True(item.State is ReadyForTestingState);
        }

        [Fact]
        public void Backlog_Item_Should_Not_Finish_With_Unfinished_Activities()
        {
            // Arrange
            BacklogItem item = new(DefinitionOfDone: "This is the DoD", Description: "Description");
            Developer dev = new(Name: "dev");
            Activity activity = new(Task: "Activity1");
            activity.AssignDeveloper(dev);
            activity.FinishTask();
            Activity activity2 = new(Task: "Activity2");
            activity2.AssignDeveloper(dev);
            activity2.FinishTask();
            Activity activity3 = new(Task: "Activity3");
            activity3.AssignDeveloper(dev);

            item.AddActivity(activity);
            item.AddActivity(activity2);
            item.AddActivity(activity3);
            item.UpdateState(new DoingState(item));
            item.AssignDeveloper(dev);

            // Act
            int sut = item.FinishTask();

            // Assert
            Assert.True(item.State is DoingState);
            Assert.True(sut == 0);
        }
    }
}
