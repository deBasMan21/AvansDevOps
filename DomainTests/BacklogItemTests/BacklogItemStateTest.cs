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
        public void Start_As_Todo()
        {
            // Arrange & Act
            BacklogItem item = new(DefinitionOfDone: "This is the DoD", Description: "Description");

            // Assert
            Assert.True(item.State is TodoState);
        }

        [Fact]
        public void Should_Not_Start_Without_A_Developer()
        {
            // Arrange 
            BacklogItem item = new(DefinitionOfDone: "This is the DoD", Description: "Description");

            // Act
            item.StartTask();

            // Assert
            Assert.True(item.State is TodoState);
        }

        // Todo

        [Fact]
        public void Todo_Should_Go_To_Doing()
        {
            // Arrange
            BacklogItem item = new(DefinitionOfDone: "This is the DoD", Description: "Description");
            Developer dev = new(Name: "dev");
            item.AssignDeveloper(dev);

            // Act
            item.StartTask();

            //Assert
            Assert.True(item.State is DoingState);
        }

        [Fact]
        public void Todo_Should_Not_FinishTask()
        {
            // Arrange
            BacklogItem item = new(DefinitionOfDone: "This is the DoD", Description: "Description");
            Developer dev = new(Name: "dev");
            item.AssignDeveloper(dev);

            // Act
            item.FinishTask();

            //Assert
            Assert.True(item.State is TodoState);
        }

        [Fact]
        public void Todo_Should_Not_StartTesting()
        {
            // Arrange
            BacklogItem item = new(DefinitionOfDone: "This is the DoD", Description: "Description");
            Developer dev = new(Name: "dev");
            item.AssignDeveloper(dev);

            // Act
            item.StartTesting();

            //Assert
            Assert.True(item.State is TodoState);
        }

        [Fact]
        public void Todo_Should_Not_SendTestRapport()
        {
            // Arrange
            BacklogItem item = new(DefinitionOfDone: "This is the DoD", Description: "Description");
            Developer dev = new(Name: "dev");
            item.AssignDeveloper(dev);

            // Act
            item.SendTestRapport(true);
            Assert.True(item.State is TodoState);
            item.SendTestRapport(true);
            Assert.True(item.State is TodoState);
        }

        [Fact]
        public void Todo_Should_Not_EvaluateTest()
        {
            // Arrange
            BacklogItem item = new(DefinitionOfDone: "This is the DoD", Description: "Description");
            Developer dev = new(Name: "dev");
            item.AssignDeveloper(dev);

            // Act
            item.EvaluateTestRapport(true);
            Assert.True(item.State is TodoState);
            item.EvaluateTestRapport(false);
            Assert.True(item.State is TodoState);
        }

        [Fact]
        public void Todo_Should_Not_InvalidateTask()
        {
            // Arrange
            BacklogItem item = new(DefinitionOfDone: "This is the DoD", Description: "Description");
            Developer dev = new(Name: "dev");
            item.AssignDeveloper(dev);

            // Act
            item.InvalidateTask();

            //Assert
            Assert.True(item.State is TodoState);
        }

        // Doing
        [Fact]
        public void Doing_Should_Go_To_ReadyForTesting()
        {
            // Arrange
            BacklogItem item = new(DefinitionOfDone: "This is the DoD", Description: "Description");
            Developer dev = new(Name: "dev");
            item.UpdateState(new DoingState(item));
            item.AssignDeveloper(dev);

            // Act
            item.FinishTask();

            //Assert
            Assert.True(item.State is ReadyForTestingState);
        }

        [Fact]
        public void Doing_Should_Not_StartTask()
        {
            // Arrange
            BacklogItem item = new(DefinitionOfDone: "This is the DoD", Description: "Description");
            Developer dev = new(Name: "dev");
            item.UpdateState(new DoingState(item));
            item.AssignDeveloper(dev);

            // Act
            item.StartTask();

            //Assert
            Assert.True(item.State is DoingState);
        }

        [Fact]
        public void Doing_Should_Not_StartTesting()
        {
            // Arrange
            BacklogItem item = new(DefinitionOfDone: "This is the DoD", Description: "Description");
            Developer dev = new(Name: "dev");
            item.UpdateState(new DoingState(item));
            item.AssignDeveloper(dev);

            // Act
            item.StartTesting();

            //Assert
            Assert.True(item.State is DoingState);
        }

        [Fact]
        public void Doing_Should_Not_SendTestRapport()
        {
            // Arrange
            BacklogItem item = new(DefinitionOfDone: "This is the DoD", Description: "Description");
            Developer dev = new(Name: "dev");
            item.UpdateState(new DoingState(item));
            item.AssignDeveloper(dev);

            // Act & Assert
            item.SendTestRapport(true);
            Assert.True(item.State is DoingState);
            item.SendTestRapport(false);
            Assert.True(item.State is DoingState);
        }

        [Fact]
        public void Doing_Should_Not_EvaluateTest()
        {
            // Arrange
            BacklogItem item = new(DefinitionOfDone: "This is the DoD", Description: "Description");
            Developer dev = new(Name: "dev");
            item.UpdateState(new DoingState(item));
            item.AssignDeveloper(dev);

            // Act & Assert
            item.EvaluateTestRapport(true);
            Assert.True(item.State is DoingState);
            item.EvaluateTestRapport(false);
            Assert.True(item.State is DoingState);
        }

        [Fact]
        public void Doing_Should_Not_InvalidateTask()
        {
            // Arrange
            BacklogItem item = new(DefinitionOfDone: "This is the DoD", Description: "Description");
            Developer dev = new(Name: "dev");
            item.UpdateState(new DoingState(item));
            item.AssignDeveloper(dev);

            // Act
            item.InvalidateTask();

            //Assert
            Assert.True(item.State is DoingState);
        }

        // Ready for testing

        [Fact]
        public void ReadyForTesting_Should_Go_To_Testing()
        {
            // Arrange
            BacklogItem item = new(DefinitionOfDone: "This is the DoD", Description: "Description");
            Developer dev = new(Name: "dev");
            item.UpdateState(new ReadyForTestingState(item));
            item.AssignDeveloper(dev);

            // Act
            item.StartTesting();

            //Assert
            Assert.True(item.State is TestingState);
        }

        [Fact]
        public void ReadyForTesting_Should_Not_StartTask()
        {
            // Arrange
            BacklogItem item = new(DefinitionOfDone: "This is the DoD", Description: "Description");
            Developer dev = new(Name: "dev");
            item.UpdateState(new ReadyForTestingState(item));
            item.AssignDeveloper(dev);

            // Act
            item.StartTask();

            //Assert
            Assert.True(item.State is ReadyForTestingState);
        }

        [Fact]
        public void ReadyForTesting_Should_Not_FinishTask()
        {
            // Arrange
            BacklogItem item = new(DefinitionOfDone: "This is the DoD", Description: "Description");
            Developer dev = new(Name: "dev");
            item.UpdateState(new ReadyForTestingState(item));
            item.AssignDeveloper(dev);

            // Act
            item.FinishTask();

            //Assert
            Assert.True(item.State is ReadyForTestingState);
        }

        [Fact]
        public void ReadyForTesting_Should_Not_SendTestRapport()
        {
            // Arrange
            BacklogItem item = new(DefinitionOfDone: "This is the DoD", Description: "Description");
            Developer dev = new(Name: "dev");
            item.UpdateState(new ReadyForTestingState(item));
            item.AssignDeveloper(dev);

            // Act
            // Act & Assert
            item.SendTestRapport(true);
            Assert.True(item.State is ReadyForTestingState);
            item.SendTestRapport(false);
            Assert.True(item.State is ReadyForTestingState);
        }

        [Fact]
        public void ReadyForTesting_Should_Not_EvaluateTest()
        {
            // Arrange
            BacklogItem item = new(DefinitionOfDone: "This is the DoD", Description: "Description");
            Developer dev = new(Name: "dev");
            item.UpdateState(new ReadyForTestingState(item));
            item.AssignDeveloper(dev);

            // Act
            // Act & Assert
            item.EvaluateTestRapport(true);
            Assert.True(item.State is ReadyForTestingState);
            item.EvaluateTestRapport(false);
            Assert.True(item.State is ReadyForTestingState);
        }

        [Fact]
        public void ReadyForTesting_Should_Not_InvalidateTask()
        {
            // Arrange
            BacklogItem item = new(DefinitionOfDone: "This is the DoD", Description: "Description");
            Developer dev = new(Name: "dev");
            item.UpdateState(new ReadyForTestingState(item));
            item.AssignDeveloper(dev);

            // Act
            item.InvalidateTask();

            //Assert
            Assert.True(item.State is ReadyForTestingState);
        }

        // Testing

        [Fact]
        public void Testing_Should_Go_To_Todo()
        {
            // Arrange
            BacklogItem item = new(DefinitionOfDone: "This is the DoD", Description: "Description");
            Developer dev = new(Name: "dev");
            item.UpdateState(new TestingState(item));
            item.AssignDeveloper(dev);

            // Act
            item.SendTestRapport(false);

            //Assert
            Assert.True(item.State is TodoState);
        }

        [Fact]
        public void Testing_Should_Go_To_Tested()
        {
            // Arrange
            BacklogItem item = new(DefinitionOfDone: "This is the DoD", Description: "Description");
            Developer dev = new(Name: "dev");
            item.UpdateState(new TestingState(item));
            item.AssignDeveloper(dev);

            // Act
            item.SendTestRapport(true);

            //Assert
            Assert.True(item.State is TestedState);
        }

        [Fact]
        public void Testing_Should_Not_StartTest()
        {
            // Arrange
            BacklogItem item = new(DefinitionOfDone: "This is the DoD", Description: "Description");
            Developer dev = new(Name: "dev");
            item.UpdateState(new TestingState(item));
            item.AssignDeveloper(dev);

            // Act
            item.StartTask();

            //Assert
            Assert.True(item.State is TestingState);
        }

        [Fact]
        public void Testing_Should_Not_FinishTask()
        {
            // Arrange
            BacklogItem item = new(DefinitionOfDone: "This is the DoD", Description: "Description");
            Developer dev = new(Name: "dev");
            item.UpdateState(new TestingState(item));
            item.AssignDeveloper(dev);

            // Act
            item.FinishTask();

            //Assert
            Assert.True(item.State is TestingState);
        }

        [Fact]
        public void Testing_Should_Not_StartTesting()
        {
            // Arrange
            BacklogItem item = new(DefinitionOfDone: "This is the DoD", Description: "Description");
            Developer dev = new(Name: "dev");
            item.UpdateState(new TestingState(item));
            item.AssignDeveloper(dev);

            // Act
            item.StartTesting();

            //Assert
            Assert.True(item.State is TestingState);
        }

        [Fact]
        public void Testing_Should_Not_EvaluateTest()
        {
            // Arrange
            BacklogItem item = new(DefinitionOfDone: "This is the DoD", Description: "Description");
            Developer dev = new(Name: "dev");
            item.UpdateState(new TestingState(item));
            item.AssignDeveloper(dev);

            // Act & Assert
            item.EvaluateTestRapport(true);
            Assert.True(item.State is TestingState);
            item.EvaluateTestRapport(false);
            Assert.True(item.State is TestingState);
        }

        [Fact]
        public void Testing_Should_Not_InvalidateTask()
        {
            // Arrange
            BacklogItem item = new(DefinitionOfDone: "This is the DoD", Description: "Description");
            Developer dev = new(Name: "dev");
            item.UpdateState(new TestingState(item));
            item.AssignDeveloper(dev);

            // Act
            item.InvalidateTask();

            //Assert
            Assert.True(item.State is TestingState);
        }

        // Tested

        [Fact]
        public void Tested_Should_Go_To_Done()
        {
            // Arrange
            BacklogItem item = new(DefinitionOfDone: "This is the DoD", Description: "Description");
            Developer dev = new(Name: "dev");
            item.UpdateState(new TestedState(item));
            item.AssignDeveloper(dev);

            // Act
            item.EvaluateTestRapport(true);

            //Assert
            Assert.True(item.State is DoneState);
        }

        [Fact]
        public void Tested_Should_Go_To_ReadyForTesting()
        {
            // Arrange
            BacklogItem item = new(DefinitionOfDone: "This is the DoD", Description: "Description");
            Developer dev = new(Name: "dev");
            item.UpdateState(new TestedState(item));
            item.AssignDeveloper(dev);

            // Act
            item.EvaluateTestRapport(false);

            //Assert
            Assert.True(item.State is ReadyForTestingState);
        }

        [Fact]
        public void Tested_Should_Not_StartTask()
        {
            // Arrange
            BacklogItem item = new(DefinitionOfDone: "This is the DoD", Description: "Description");
            Developer dev = new(Name: "dev");
            item.UpdateState(new TestedState(item));
            item.AssignDeveloper(dev);

            // Act
            item.StartTask();

            //Assert
            Assert.True(item.State is TestedState);
        }

        [Fact]
        public void Tested_Should_Not_FinishTask()
        {
            // Arrange
            BacklogItem item = new(DefinitionOfDone: "This is the DoD", Description: "Description");
            Developer dev = new(Name: "dev");
            item.UpdateState(new TestedState(item));
            item.AssignDeveloper(dev);

            // Act
            item.FinishTask();

            //Assert
            Assert.True(item.State is TestedState);
        }

        [Fact]
        public void Tested_Should_Not_StartTesting()
        {
            // Arrange
            BacklogItem item = new(DefinitionOfDone: "This is the DoD", Description: "Description");
            Developer dev = new(Name: "dev");
            item.UpdateState(new TestedState(item));
            item.AssignDeveloper(dev);

            // Act
            item.StartTesting();

            //Assert
            Assert.True(item.State is TestedState);
        }

        [Fact]
        public void Tested_Should_Not_SendTestRapport()
        {
            // Arrange
            BacklogItem item = new(DefinitionOfDone: "This is the DoD", Description: "Description");
            Developer dev = new(Name: "dev");
            item.UpdateState(new TestedState(item));
            item.AssignDeveloper(dev);

            // Act & Assert
            item.SendTestRapport(true);
            Assert.True(item.State is TestedState);
            item.SendTestRapport(false);
            Assert.True(item.State is TestedState);
        }

        [Fact]
        public void Tested_Should_Not_InvalidateTask()
        {
            // Arrange
            BacklogItem item = new(DefinitionOfDone: "This is the DoD", Description: "Description");
            Developer dev = new(Name: "dev");
            item.UpdateState(new TestedState(item));
            item.AssignDeveloper(dev);

            // Act
            item.InvalidateTask();

            //Assert
            Assert.True(item.State is TestedState);
        }

        // Done

        [Fact]
        public void Done_Should_Go_To_Todo()
        {
            // Arrange
            BacklogItem item = new(DefinitionOfDone: "This is the DoD", Description: "Description");
            Developer dev = new(Name: "dev");
            item.UpdateState(new DoneState(item));
            item.AssignDeveloper(dev);

            // Act
            item.InvalidateTask();

            //Assert
            Assert.True(item.State is TodoState);
        }

        [Fact]
        public void Done_Should_Not_StartTask()
        {
            // Arrange
            BacklogItem item = new(DefinitionOfDone: "This is the DoD", Description: "Description");
            Developer dev = new(Name: "dev");
            item.UpdateState(new DoneState(item));
            item.AssignDeveloper(dev);

            // Act
            item.StartTask();

            //Assert
            Assert.True(item.State is DoneState);
        }

        [Fact]
        public void Done_Should_Not_FinishTask()
        {
            // Arrange
            BacklogItem item = new(DefinitionOfDone: "This is the DoD", Description: "Description");
            Developer dev = new(Name: "dev");
            item.UpdateState(new DoneState(item));
            item.AssignDeveloper(dev);

            // Act
            item.FinishTask();

            //Assert
            Assert.True(item.State is DoneState);
        }

        [Fact]
        public void Done_Should_Not_StartTesting()
        {
            // Arrange
            BacklogItem item = new(DefinitionOfDone: "This is the DoD", Description: "Description");
            Developer dev = new(Name: "dev");
            item.UpdateState(new DoneState(item));
            item.AssignDeveloper(dev);

            // Act
            item.StartTesting();

            //Assert
            Assert.True(item.State is DoneState);
        }

        [Fact]
        public void Done_Should_Not_SendTestRapport()
        {
            // Arrange
            BacklogItem item = new(DefinitionOfDone: "This is the DoD", Description: "Description");
            Developer dev = new(Name: "dev");
            item.UpdateState(new DoneState(item));
            item.AssignDeveloper(dev);

            // Act & Assert
            item.SendTestRapport(true);
            Assert.True(item.State is DoneState);
            item.SendTestRapport(false);
            Assert.True(item.State is DoneState);
        }

        [Fact]
        public void Done_Should_Not_EvaluateTest()
        {
            // Arrange
            BacklogItem item = new(DefinitionOfDone: "This is the DoD", Description: "Description");
            Developer dev = new(Name: "dev");
            item.UpdateState(new DoneState(item));
            item.AssignDeveloper(dev);

            // Act & Assert
            item.EvaluateTestRapport(true);
            Assert.True(item.State is DoneState);
            item.EvaluateTestRapport(false);
            Assert.True(item.State is DoneState);
        }
    }
}