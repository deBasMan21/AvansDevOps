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
        public void ShouldNotStartWithoutADeveloper()
        {
            // Arrange 
            BacklogItem item = new(DefinitionOfDone: "This is the DoD", Description: "Description");

            // Act
            item.StartTask();

            // Assert
            Assert.True(item.State.GetType() == typeof(TodoState));
        }

        [Fact]
        public void SingleTestToDone()
        {
            // Arrange
            BacklogItem item = new(DefinitionOfDone: "This is the DoD", Description: "Description");
            Developer dev = new(Name: "dev");
            item.AssignDeveloper(dev);

            // Act & Assert
            item.StartTask();
            Assert.True(item.State.GetType() == typeof(DoingState));

            item.FinishTask();
            Assert.True(item.State.GetType() == typeof(ReadyForTestingState));

            item.StartTesting();
            Assert.True(item.State.GetType() == typeof(TestingState));

            item.SendTestRapport(passed: true);
            Assert.True(item.State.GetType() == typeof(TestedState));

            item.EvaluateTestRapport(passed: true);
            Assert.True(item.State.GetType() == typeof(DoneState));
        }

        [Fact]
        public void ReopenClosedItem()
        {
            // Arrange
            BacklogItem item = new(DefinitionOfDone: "This is the DoD", Description: "Description");
            Developer dev = new(Name: "dev");
            item.AssignDeveloper(dev);

            // Act & Assert
            item.StartTask();
            Assert.True(item.State.GetType() == typeof(DoingState));

            item.FinishTask();
            Assert.True(item.State.GetType() == typeof(ReadyForTestingState));

            item.StartTesting();
            Assert.True(item.State.GetType() == typeof(TestingState));

            item.SendTestRapport(passed: true);
            Assert.True(item.State.GetType() == typeof(TestedState));

            item.EvaluateTestRapport(passed: true);
            Assert.True(item.State.GetType() == typeof(DoneState));

            item.InvalidateTask();
            Assert.True(item.State.GetType() == typeof(TodoState));
        }

        [Fact]
        public void RetestAndCloseTask()
        {
            // Arrange
            BacklogItem item = new(DefinitionOfDone: "This is the DoD", Description: "Description");
            Developer dev = new(Name: "dev");
            item.AssignDeveloper(dev);

            // Act & Assert
            item.StartTask();
            Assert.True(item.State.GetType() == typeof(DoingState));

            item.FinishTask();
            Assert.True(item.State.GetType() == typeof(ReadyForTestingState));

            item.StartTesting();
            Assert.True(item.State.GetType() == typeof(TestingState));

            item.SendTestRapport(passed: true);
            Assert.True(item.State.GetType() == typeof(TestedState));

            item.EvaluateTestRapport(passed: false);
            Assert.True(item.State.GetType() == typeof(ReadyForTestingState));

            item.StartTesting();
            Assert.True(item.State.GetType() == typeof(TestingState));

            item.SendTestRapport(passed: true);
            Assert.True(item.State.GetType() == typeof(TestedState));

            item.EvaluateTestRapport(passed: true);
            Assert.True(item.State.GetType() == typeof(DoneState));
        }

        [Fact]
        public void InvalidateByTester()
        {
            // Arrange
            BacklogItem item = new(DefinitionOfDone: "This is the DoD", Description: "Description");
            Developer dev = new(Name: "dev");
            item.AssignDeveloper(dev);

            // Act & Assert
            item.StartTask();
            Assert.True(item.State.GetType() == typeof(DoingState));

            item.FinishTask();
            Assert.True(item.State.GetType() == typeof(ReadyForTestingState));

            item.StartTesting();
            Assert.True(item.State.GetType() == typeof(TestingState));

            item.SendTestRapport(passed: false);
            Assert.True(item.State.GetType() == typeof(TodoState));
        }

        [Fact]
        public void RetestAndRejectItem()
        {
            // Arrange
            BacklogItem item = new(DefinitionOfDone: "This is the DoD", Description: "Description");
            Developer dev = new(Name: "dev");
            item.AssignDeveloper(dev);

            // Act & Assert
            item.StartTask();
            Assert.True(item.State.GetType() == typeof(DoingState));

            item.FinishTask();
            Assert.True(item.State.GetType() == typeof(ReadyForTestingState));

            item.StartTesting();
            Assert.True(item.State.GetType() == typeof(TestingState));

            item.SendTestRapport(passed: true);
            Assert.True(item.State.GetType() == typeof(TestedState));

            item.EvaluateTestRapport(passed: false);
            Assert.True(item.State.GetType() == typeof(ReadyForTestingState));

            item.StartTesting();
            Assert.True(item.State.GetType() == typeof(TestingState));

            item.SendTestRapport(passed: false);
            Assert.True(item.State.GetType() == typeof(TodoState));
        }

        [Fact]
        public void TodoShouldOnlyStartATest()
        {
            // Arrange
            BacklogItem item = new(DefinitionOfDone: "This is the DoD", Description: "Description");
            Developer dev = new(Name: "dev");
            item.AssignDeveloper(dev);

            // Act & Assert

            item.FinishTask();
            Assert.True(item.State.GetType() == typeof(TodoState));

            item.StartTesting();
            Assert.True(item.State.GetType() == typeof(TodoState));

            item.SendTestRapport(passed: false);
            Assert.True(item.State.GetType() == typeof(TodoState));

            item.SendTestRapport(passed: true);
            Assert.True(item.State.GetType() == typeof(TodoState));

            item.EvaluateTestRapport(passed: true);
            Assert.True(item.State.GetType() == typeof(TodoState));

            item.EvaluateTestRapport(passed: false);
            Assert.True(item.State.GetType() == typeof(TodoState));

            item.InvalidateTask();
            Assert.True(item.State.GetType() == typeof(TodoState));
        }

        [Fact]
        public void DoingShouldOnlyFinishATask()
        {
            // Arrange
            BacklogItem item = new(DefinitionOfDone: "This is the DoD", Description: "Description");
            item.UpdateState(new DoingState(item));
            Developer dev = new(Name: "dev");
            item.AssignDeveloper(dev);

            // Act & Assert
            item.StartTask();
            Assert.True(item.State.GetType() == typeof(DoingState));

            item.StartTesting();
            Assert.True(item.State.GetType() == typeof(DoingState));

            item.SendTestRapport(passed: false);
            Assert.True(item.State.GetType() == typeof(DoingState));

            item.SendTestRapport(passed: true);
            Assert.True(item.State.GetType() == typeof(DoingState));

            item.EvaluateTestRapport(passed: true);
            Assert.True(item.State.GetType() == typeof(DoingState));

            item.EvaluateTestRapport(passed: false);
            Assert.True(item.State.GetType() == typeof(DoingState));

            item.InvalidateTask();
            Assert.True(item.State.GetType() == typeof(DoingState));
        }

        [Fact]
        public void ReadyForTestingShouldOnlyTestATask()
        {
            // Arrange
            BacklogItem item = new(DefinitionOfDone: "This is the DoD", Description: "Description");
            item.UpdateState(new ReadyForTestingState(item));
            Developer dev = new(Name: "dev");
            item.AssignDeveloper(dev);

            // Act & Assert
            item.StartTask();
            Assert.True(item.State.GetType() == typeof(ReadyForTestingState));

            item.FinishTask();
            Assert.True(item.State.GetType() == typeof(ReadyForTestingState));

            item.SendTestRapport(passed: false);
            Assert.True(item.State.GetType() == typeof(ReadyForTestingState));

            item.SendTestRapport(passed: true);
            Assert.True(item.State.GetType() == typeof(ReadyForTestingState));

            item.EvaluateTestRapport(passed: true);
            Assert.True(item.State.GetType() == typeof(ReadyForTestingState));

            item.EvaluateTestRapport(passed: false);
            Assert.True(item.State.GetType() == typeof(ReadyForTestingState));

            item.InvalidateTask();
            Assert.True(item.State.GetType() == typeof(ReadyForTestingState));
        }

        [Fact]
        public void TestingShouldOnlySendTestRapport()
        {
            // Arrange
            BacklogItem item = new(DefinitionOfDone: "This is the DoD", Description: "Description");
            item.UpdateState(new TestingState(item));
            Developer dev = new(Name: "dev");
            item.AssignDeveloper(dev);

            // Act & Assert
            item.StartTask();
            Assert.True(item.State.GetType() == typeof(TestingState));

            item.FinishTask();
            Assert.True(item.State.GetType() == typeof(TestingState));

            item.StartTesting();
            Assert.True(item.State.GetType() == typeof(TestingState));

            item.EvaluateTestRapport(passed: true);
            Assert.True(item.State.GetType() == typeof(TestingState));

            item.EvaluateTestRapport(passed: false);
            Assert.True(item.State.GetType() == typeof(TestingState));

            item.InvalidateTask();
            Assert.True(item.State.GetType() == typeof(TestingState));
        }



        [Fact]
        public void TestedShouldOnlyEvaluateTestRapport()
        {
            // Arrange
            BacklogItem item = new(DefinitionOfDone: "This is the DoD", Description: "Description");
            item.UpdateState(new TestedState(item));
            Developer dev = new(Name: "dev");
            item.AssignDeveloper(dev);

            // Act & Assert
            item.StartTask();
            Assert.True(item.State.GetType() == typeof(TestedState));

            item.FinishTask();
            Assert.True(item.State.GetType() == typeof(TestedState));

            item.StartTesting();
            Assert.True(item.State.GetType() == typeof(TestedState));

            item.SendTestRapport(passed: true);
            Assert.True(item.State.GetType() == typeof(TestedState));

            item.SendTestRapport(passed: false);
            Assert.True(item.State.GetType() == typeof(TestedState));

            item.InvalidateTask();
            Assert.True(item.State.GetType() == typeof(TestedState));
        }

        [Fact]
        public void DoneShouldOnlyInvalidateATask()
        {
            // Arrange
            BacklogItem item = new(DefinitionOfDone: "This is the DoD", Description: "Description");
            item.UpdateState(new DoneState(item));
            Developer dev = new(Name: "dev");
            item.AssignDeveloper(dev);

            // Act & Assert
            item.StartTask();
            Assert.True(item.State.GetType() == typeof(DoneState));

            item.FinishTask();
            Assert.True(item.State.GetType() == typeof(DoneState));

            item.StartTesting();
            Assert.True(item.State.GetType() == typeof(DoneState));

            item.SendTestRapport(passed: false);
            Assert.True(item.State.GetType() == typeof(DoneState));

            item.SendTestRapport(passed: true);
            Assert.True(item.State.GetType() == typeof(DoneState));

            item.SendTestRapport(passed: true);
            Assert.True(item.State.GetType() == typeof(DoneState));

            item.SendTestRapport(passed: false);
            Assert.True(item.State.GetType() == typeof(DoneState));
        }
    }
}