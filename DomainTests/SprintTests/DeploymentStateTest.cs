using AvansDevOps;
using AvansDevOps.SprintAbstraction;
using AvansDevOps.SprintState;
using AvansDevOps.SprintDeploymentState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansDevOps.Pipeline;

namespace DomainTests.SprintTests
{
    public class DeploymentStateTest
    {
        // Not Ready to deploy

        [Fact]
        public void NotReadyToDeploy_Should_Go_To_ReadyToDeploy()
        {
            // Arrange
            ReleaseSprint sprint = new ReleaseSprint(Name: "sprint1", StartDate: DateTime.Now, EndDate: DateTime.Now.AddDays(20));
            sprint.UpdateDeploymentState(new NotReadyToDeploy(sprint));


            // Act
            sprint.ApproveDeployment();

            // Assert
            Assert.True(sprint.deploymentState is ReadyToDeployState);
        }

        [Fact]
        public void NotReadyToDeploy_Should_Go_To_DeploymentCancelled()
        {
            // Arrange
            ReleaseSprint sprint = new ReleaseSprint(Name: "sprint1", StartDate: DateTime.Now, EndDate: DateTime.Now.AddDays(20));
            sprint.UpdateDeploymentState(new NotReadyToDeploy(sprint));

            // Act
            sprint.CancelDeployment();

            // Assert
            Assert.True(sprint.deploymentState is DeploymentCancelledState);
        }


        [Fact]
        public void NotReadyToDeploy_Should_Not_Go_To_InDeployment()
        {
            // Arrange
            ReleaseSprint sprint = new ReleaseSprint(Name: "sprint1", StartDate: DateTime.Now, EndDate: DateTime.Now.AddDays(20));
            sprint.UpdateDeploymentState(new NotReadyToDeploy(sprint));
            DeploymentPipeline pipeline = new();

            pipeline.AddComponent(new SourcesAction("ThisIsSupposeToBeAnUrls"));
            pipeline.AddComponent(new PackageAction(new() { "xunit (2.4.2)", "Moq (4.18.4)" }));
            pipeline.AddComponent(new BuildAction(".NET Core build"));
            pipeline.AddComponent(new TestAction("XUnit 2.4.2"));
            pipeline.AddComponent(new AnalyseAction("SonarQube"));
            pipeline.AddComponent(new DeployAction("Azure"));
            pipeline.AddComponent(new UtilityAction(new() { "UtilityAction1", "UtilityAction2" }));

            // Act
            sprint.StartDeployment(pipeline);

            // Assert
            Assert.True(sprint.deploymentState is NotReadyToDeploy);
        }

        [Fact]
        public void NotReadyToDeploy_Should_Not_Go_To_DeploymentFailed()
        {
            // Arrange
            ReleaseSprint sprint = new ReleaseSprint(Name: "sprint1", StartDate: DateTime.Now, EndDate: DateTime.Now.AddDays(20));
            sprint.UpdateDeploymentState(new NotReadyToDeploy(sprint));

            // Act
            sprint.FinishDeployment(succeeded: false);

            // Assert
            Assert.True(sprint.deploymentState is NotReadyToDeploy);
        }

        [Fact]
        public void NotReadyToDeploy_Should_Not_RestartDeployment()
        {
            // Arrange
            ReleaseSprint sprint = new ReleaseSprint(Name: "sprint1", StartDate: DateTime.Now, EndDate: DateTime.Now.AddDays(20));
            sprint.UpdateDeploymentState(new NotReadyToDeploy(sprint));

            // Act
            sprint.RestartDeployment();

            // Assert
            Assert.True(sprint.deploymentState is NotReadyToDeploy);
        }

        [Fact]
        public void NotReadyToDeploy_Should_Not_Go_To_ReleasedDeployment()
        {
            // Arrange
            ReleaseSprint sprint = new ReleaseSprint(Name: "sprint1", StartDate: DateTime.Now, EndDate: DateTime.Now.AddDays(20));
            sprint.UpdateDeploymentState(new NotReadyToDeploy(sprint));

            // Act
            sprint.FinishDeployment(succeeded: true);

            // Assert
            Assert.True(sprint.deploymentState is NotReadyToDeploy);
        }


        // Ready to deploy

        [Fact]
        public void ReadyToDeploy_Should_Go_To_InDeployment()
        {
            // Arrange
            ReleaseSprint sprint = new ReleaseSprint(Name: "sprint1", StartDate: DateTime.Now, EndDate: DateTime.Now.AddDays(20));
            sprint.UpdateDeploymentState(new ReadyToDeployState(sprint));

            DeploymentPipeline pipeline = new();

            pipeline.AddComponent(new SourcesAction("ThisIsSupposeToBeAnUrls"));
            pipeline.AddComponent(new PackageAction(new() { "xunit (2.4.2)", "Moq (4.18.4)" }));
            pipeline.AddComponent(new BuildAction(".NET Core build"));
            pipeline.AddComponent(new TestAction("XUnit 2.4.2"));
            pipeline.AddComponent(new AnalyseAction("SonarQube"));
            pipeline.AddComponent(new DeployAction("Azure"));
            pipeline.AddComponent(new UtilityAction(new() { "UtilityAction1", "UtilityAction2" }));

            // Act
            sprint.StartDeployment(pipeline);

            // Assert
            Assert.True(sprint.deploymentState is InDeploymentState);
        }

        [Fact]
        public void ReadyToDeploy_Should_Not_ApproveDeployment()
        {
            // Arrange
            ReleaseSprint sprint = new ReleaseSprint(Name: "sprint1", StartDate: DateTime.Now, EndDate: DateTime.Now.AddDays(20));
            sprint.UpdateDeploymentState(new ReadyToDeployState(sprint));


            // Act
            sprint.ApproveDeployment();

            // Assert
            Assert.True(sprint.deploymentState is ReadyToDeployState);
        }

        [Fact]
        public void ReadyToDeploy_Should_Not_Go_To_DeploymentFailed()
        {
            // Arrange
            ReleaseSprint sprint = new ReleaseSprint(Name: "sprint1", StartDate: DateTime.Now, EndDate: DateTime.Now.AddDays(20));
            sprint.UpdateDeploymentState(new ReadyToDeployState(sprint));


            // Act
            sprint.FinishDeployment(succeeded: false);

            // Assert
            Assert.True(sprint.deploymentState is ReadyToDeployState);
        }

        [Fact]
        public void ReadyToDeploy_Should_Not_RestartDeployment()
        {
            // Arrange
            ReleaseSprint sprint = new ReleaseSprint(Name: "sprint1", StartDate: DateTime.Now, EndDate: DateTime.Now.AddDays(20));
            sprint.UpdateDeploymentState(new ReadyToDeployState(sprint));


            // Act
            sprint.RestartDeployment();

            // Assert
            Assert.True(sprint.deploymentState is ReadyToDeployState);
        }

        [Fact]
        public void ReadyToDeploy_Should_Not_Go_To_ReleasedDeployment()
        {
            // Arrange
            ReleaseSprint sprint = new ReleaseSprint(Name: "sprint1", StartDate: DateTime.Now, EndDate: DateTime.Now.AddDays(20));
            sprint.UpdateDeploymentState(new ReadyToDeployState(sprint));


            // Act
            sprint.FinishDeployment(succeeded: true);

            // Assert
            Assert.True(sprint.deploymentState is ReadyToDeployState);
        }

        [Fact]
        public void ReadyToDeploy_Should_Not_Go_To_deploymentCancelled()
        {
            // Arrange
            ReleaseSprint sprint = new ReleaseSprint(Name: "sprint1", StartDate: DateTime.Now, EndDate: DateTime.Now.AddDays(20));
            sprint.UpdateDeploymentState(new ReadyToDeployState(sprint));


            // Act
            sprint.CancelDeployment();

            // Assert
            Assert.True(sprint.deploymentState is ReadyToDeployState);
        }

        // In deployment

        [Fact]
        public void InDeployment_Should_Go_To_DeploymentFailed()
        {
            // Arrange
            ReleaseSprint sprint = new ReleaseSprint(Name: "sprint1", StartDate: DateTime.Now, EndDate: DateTime.Now.AddDays(20));
            sprint.UpdateDeploymentState(new InDeploymentState(sprint));


            // Act
            sprint.FinishDeployment(succeeded: false);

            // Assert
            Assert.True(sprint.deploymentState is DeploymentFailedState);
        }

        [Fact]
        public void InDeployment_Should_Go_To_ReleasedDeployment()
        {
            // Arrange
            ReleaseSprint sprint = new ReleaseSprint(Name: "sprint1", StartDate: DateTime.Now, EndDate: DateTime.Now.AddDays(20));
            sprint.UpdateDeploymentState(new InDeploymentState(sprint));


            // Act
            sprint.FinishDeployment(succeeded: true);

            // Assert
            Assert.True(sprint.deploymentState is ReleasedDeploymentState);
        }

        [Fact]
        public void InDeployment_Should_Not_ApproveDeployment()
        {
            // Arrange
            ReleaseSprint sprint = new ReleaseSprint(Name: "sprint1", StartDate: DateTime.Now, EndDate: DateTime.Now.AddDays(20));
            sprint.UpdateDeploymentState(new InDeploymentState(sprint));


            // Act
            sprint.ApproveDeployment();

            // Assert
            Assert.True(sprint.deploymentState is InDeploymentState);
        }

        [Fact]
        public void InDeployment_Should_Not_StartDeployment()
        {
            // Arrange
            ReleaseSprint sprint = new ReleaseSprint(Name: "sprint1", StartDate: DateTime.Now, EndDate: DateTime.Now.AddDays(20));
            sprint.UpdateDeploymentState(new InDeploymentState(sprint));
            DeploymentPipeline pipeline = new();

            pipeline.AddComponent(new SourcesAction("ThisIsSupposeToBeAnUrls"));
            pipeline.AddComponent(new PackageAction(new() { "xunit (2.4.2)", "Moq (4.18.4)" }));
            pipeline.AddComponent(new BuildAction(".NET Core build"));
            pipeline.AddComponent(new TestAction("XUnit 2.4.2"));
            pipeline.AddComponent(new AnalyseAction("SonarQube"));
            pipeline.AddComponent(new DeployAction("Azure"));
            pipeline.AddComponent(new UtilityAction(new() { "UtilityAction1", "UtilityAction2" }));

            // Act
            sprint.StartDeployment(pipeline);

            // Assert
            Assert.True(sprint.deploymentState is InDeploymentState);
        }

        [Fact]
        public void InDeployment_Should_Not_RestartDeployment()
        {
            // Arrange
            ReleaseSprint sprint = new ReleaseSprint(Name: "sprint1", StartDate: DateTime.Now, EndDate: DateTime.Now.AddDays(20));
            sprint.UpdateDeploymentState(new InDeploymentState(sprint));

            // Act
            sprint.RestartDeployment();

            // Assert
            Assert.True(sprint.deploymentState is InDeploymentState);
        }

        [Fact]
        public void InDeployment_Should_Not_Go_To_DeploymentCancelled()
        {
            // Arrange
            ReleaseSprint sprint = new ReleaseSprint(Name: "sprint1", StartDate: DateTime.Now, EndDate: DateTime.Now.AddDays(20));
            sprint.UpdateDeploymentState(new InDeploymentState(sprint));

            // Act
            sprint.CancelDeployment();

            // Assert
            Assert.True(sprint.deploymentState is InDeploymentState);
        }

        // Released Deployment

        [Fact]
        public void Released_Should_Not_ApproveDeployment()
        {
            // Arrange
            ReleaseSprint sprint = new ReleaseSprint(Name: "sprint1", StartDate: DateTime.Now, EndDate: DateTime.Now.AddDays(20));
            sprint.UpdateDeploymentState(new ReleasedDeploymentState(sprint));

            // Act
            sprint.ApproveDeployment();

            // Assert
            Assert.True(sprint.deploymentState is ReleasedDeploymentState);
        }

        [Fact]
        public void Released_Should_Not_StartDeployment()
        {
            // Arrange
            ReleaseSprint sprint = new ReleaseSprint(Name: "sprint1", StartDate: DateTime.Now, EndDate: DateTime.Now.AddDays(20));
            sprint.UpdateDeploymentState(new ReleasedDeploymentState(sprint));
            DeploymentPipeline pipeline = new();

            pipeline.AddComponent(new SourcesAction("ThisIsSupposeToBeAnUrls"));
            pipeline.AddComponent(new PackageAction(new() { "xunit (2.4.2)", "Moq (4.18.4)" }));
            pipeline.AddComponent(new BuildAction(".NET Core build"));
            pipeline.AddComponent(new TestAction("XUnit 2.4.2"));
            pipeline.AddComponent(new AnalyseAction("SonarQube"));
            pipeline.AddComponent(new DeployAction("Azure"));
            pipeline.AddComponent(new UtilityAction(new() { "UtilityAction1", "UtilityAction2" }));

            // Act
            sprint.StartDeployment(pipeline);

            // Assert
            Assert.True(sprint.deploymentState is ReleasedDeploymentState);
        }


        [Fact]
        public void Released_Should_Not_CancelDeployment()
        {
            // Arrange
            ReleaseSprint sprint = new ReleaseSprint(Name: "sprint1", StartDate: DateTime.Now, EndDate: DateTime.Now.AddDays(20));
            sprint.UpdateDeploymentState(new ReleasedDeploymentState(sprint));

            // Act
            sprint.CancelDeployment();

            // Assert
            Assert.True(sprint.deploymentState is ReleasedDeploymentState);
        }


        [Fact]
        public void Released_Should_Not_SucceedDeployment()
        {
            // Arrange
            ReleaseSprint sprint = new ReleaseSprint(Name: "sprint1", StartDate: DateTime.Now, EndDate: DateTime.Now.AddDays(20));
            sprint.UpdateDeploymentState(new ReleasedDeploymentState(sprint));

            // Act
            sprint.FinishDeployment(succeeded: true);

            // Assert
            Assert.True(sprint.deploymentState is ReleasedDeploymentState);
        }

        [Fact]
        public void Released_Should_Not_FailDeployment()
        {
            // Arrange
            ReleaseSprint sprint = new ReleaseSprint(Name: "sprint1", StartDate: DateTime.Now, EndDate: DateTime.Now.AddDays(20));
            sprint.UpdateDeploymentState(new ReleasedDeploymentState(sprint));

            // Act
            sprint.FinishDeployment(succeeded: false);

            // Assert
            Assert.True(sprint.deploymentState is ReleasedDeploymentState);
        }


        [Fact]
        public void Released_Should_Not_RestartDeployment()
        {
            // Arrange
            ReleaseSprint sprint = new ReleaseSprint(Name: "sprint1", StartDate: DateTime.Now, EndDate: DateTime.Now.AddDays(20));
            sprint.UpdateDeploymentState(new ReleasedDeploymentState(sprint));

            // Act
            sprint.RestartDeployment();

            // Assert
            Assert.True(sprint.deploymentState is ReleasedDeploymentState);
        }

        // DeploymentFailed

        [Fact]
        public void DeploymentFailed_Should_Go_To_ReadyToDeploy()
        {
            // Arrange
            ReleaseSprint sprint = new ReleaseSprint(Name: "sprint1", StartDate: DateTime.Now, EndDate: DateTime.Now.AddDays(20));
            sprint.UpdateDeploymentState(new DeploymentFailedState(sprint));

            // Act
            sprint.RestartDeployment();

            // Assert
            Assert.True(sprint.deploymentState is ReadyToDeployState);

        }

        [Fact]
        public void DeploymentFailed_Should_Go_To_DeploymentCancelled()
        {
            // Arrange
            ReleaseSprint sprint = new ReleaseSprint(Name: "sprint1", StartDate: DateTime.Now, EndDate: DateTime.Now.AddDays(20));
            sprint.UpdateDeploymentState(new DeploymentFailedState(sprint));

            // Act
            sprint.CancelDeployment();

            // Assert
            Assert.True(sprint.deploymentState is DeploymentCancelledState);
        }


        [Fact]
        public void DeploymentFailed_Should_Not_ApproveDeployment()
        {
            // Arrange
            ReleaseSprint sprint = new ReleaseSprint(Name: "sprint1", StartDate: DateTime.Now, EndDate: DateTime.Now.AddDays(20));
            sprint.UpdateDeploymentState(new DeploymentFailedState(sprint));

            // Act
            sprint.ApproveDeployment();

            // Assert
            Assert.True(sprint.deploymentState is DeploymentFailedState);
        }

        [Fact]
        public void DeploymentFailed_Should_Not_StartDeployment()
        {
            // Arrange
            ReleaseSprint sprint = new ReleaseSprint(Name: "sprint1", StartDate: DateTime.Now, EndDate: DateTime.Now.AddDays(20));
            sprint.UpdateDeploymentState(new DeploymentFailedState(sprint));
            DeploymentPipeline pipeline = new();

            pipeline.AddComponent(new SourcesAction("ThisIsSupposeToBeAnUrls"));
            pipeline.AddComponent(new PackageAction(new() { "xunit (2.4.2)", "Moq (4.18.4)" }));
            pipeline.AddComponent(new BuildAction(".NET Core build"));
            pipeline.AddComponent(new TestAction("XUnit 2.4.2"));
            pipeline.AddComponent(new AnalyseAction("SonarQube"));
            pipeline.AddComponent(new DeployAction("Azure"));
            pipeline.AddComponent(new UtilityAction(new() { "UtilityAction1", "UtilityAction2" }));

            // Act
            sprint.StartDeployment(pipeline);


            // Assert
            Assert.True(sprint.deploymentState is DeploymentFailedState);
        }


        [Fact]
        public void DeploymentFailed_Should_Not_FailDeployment()
        {
            // Arrange
            ReleaseSprint sprint = new ReleaseSprint(Name: "sprint1", StartDate: DateTime.Now, EndDate: DateTime.Now.AddDays(20));
            sprint.UpdateDeploymentState(new DeploymentFailedState(sprint));

            // Act
            sprint.FinishDeployment(succeeded: false);

            // Assert
            Assert.True(sprint.deploymentState is DeploymentFailedState);
        }

        [Fact]
        public void DeploymentFailed_Should_Not_SucceedDeployment()
        {
            // Arrange
            ReleaseSprint sprint = new ReleaseSprint(Name: "sprint1", StartDate: DateTime.Now, EndDate: DateTime.Now.AddDays(20));
            sprint.UpdateDeploymentState(new DeploymentFailedState(sprint));

            // Act
            sprint.FinishDeployment(succeeded: true);

            // Assert
            Assert.True(sprint.deploymentState is DeploymentFailedState);
        }


        //Deploymentcancelled


        [Fact]
        public void DeploymentCancelled_Should_Not_ApproveDeployment()
        {
            // Arrange
            ReleaseSprint sprint = new ReleaseSprint(Name: "sprint1", StartDate: DateTime.Now, EndDate: DateTime.Now.AddDays(20));
            sprint.UpdateDeploymentState(new DeploymentCancelledState(sprint));

            // Act
            sprint.ApproveDeployment();

            // Assert
            Assert.True(sprint.deploymentState is DeploymentCancelledState);
        }

        [Fact]
        public void DeploymentCancelled_Should_Not_CancelDeployment()
        {
            // Arrange
            ReleaseSprint sprint = new ReleaseSprint(Name: "sprint1", StartDate: DateTime.Now, EndDate: DateTime.Now.AddDays(20));
            sprint.UpdateDeploymentState(new DeploymentCancelledState(sprint));

            // Act
            sprint.CancelDeployment();

            // Assert
            Assert.True(sprint.deploymentState is DeploymentCancelledState);
        }

        [Fact]
        public void DeploymentCancelled_Should_Not_StartDeployment()
        {
            // Arrange
            ReleaseSprint sprint = new ReleaseSprint(Name: "sprint1", StartDate: DateTime.Now, EndDate: DateTime.Now.AddDays(20));
            sprint.UpdateDeploymentState(new DeploymentCancelledState(sprint));
            DeploymentPipeline pipeline = new();

            pipeline.AddComponent(new SourcesAction("ThisIsSupposeToBeAnUrls"));
            pipeline.AddComponent(new PackageAction(new() { "xunit (2.4.2)", "Moq (4.18.4)" }));
            pipeline.AddComponent(new BuildAction(".NET Core build"));
            pipeline.AddComponent(new TestAction("XUnit 2.4.2"));
            pipeline.AddComponent(new AnalyseAction("SonarQube"));
            pipeline.AddComponent(new DeployAction("Azure"));
            pipeline.AddComponent(new UtilityAction(new() { "UtilityAction1", "UtilityAction2" }));

            // Act
            sprint.StartDeployment(pipeline);

            // Assert
            Assert.True(sprint.deploymentState is DeploymentCancelledState);
        }

        [Fact]
        public void DeploymentCancelled_Should_Not_RestartDeployment()
        {
            // Arrange
            ReleaseSprint sprint = new ReleaseSprint(Name: "sprint1", StartDate: DateTime.Now, EndDate: DateTime.Now.AddDays(20));
            sprint.UpdateDeploymentState(new DeploymentCancelledState(sprint));

            // Act
            sprint.RestartDeployment();

            // Assert
            Assert.True(sprint.deploymentState is DeploymentCancelledState);
        }

        [Fact]
        public void DeploymentCancelled_Should_Not_FailDeployment()
        {
            // Arrange
            ReleaseSprint sprint = new ReleaseSprint(Name: "sprint1", StartDate: DateTime.Now, EndDate: DateTime.Now.AddDays(20));
            sprint.UpdateDeploymentState(new DeploymentCancelledState(sprint));

            // Act
            sprint.FinishDeployment(succeeded: false);

            // Assert
            Assert.True(sprint.deploymentState is DeploymentCancelledState);
        }

        [Fact]
        public void DeploymentCancelled_Should_Not_SucceedDeployment()
        {
            // Arrange
            ReleaseSprint sprint = new ReleaseSprint(Name: "sprint1", StartDate: DateTime.Now, EndDate: DateTime.Now.AddDays(20));
            sprint.UpdateDeploymentState(new DeploymentCancelledState(sprint));

            // Act
            sprint.FinishDeployment(succeeded: true);

            // Assert
            Assert.True(sprint.deploymentState is DeploymentCancelledState);
        }
    }
}