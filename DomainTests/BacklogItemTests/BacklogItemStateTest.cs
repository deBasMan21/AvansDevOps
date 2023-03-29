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
    public class BacklogItemStateTest
    {
        [Fact]
        public void StartAsTodo()
        {
            // Arrange & Act
            BacklogItem item = new(DefinitionOfDone: "This is the DoD", Description: "Description");
            
            // Assert
            Assert.True(item.State.GetType() == typeof(TodoState));
        }

        [Fact]
        public void MoveToInProgress()
        {
            // Arrange
            BacklogItem item = new(DefinitionOfDone: "This is the DoD", Description: "Description");
            Developer dev = new(Name: "dev");
            item.AssignDeveloper(dev);

            // Act
            item.StartTask();

            // Assert
            // Assert.True(item.State.GetType() == typeof(InProgressState));
        }
    }
}
