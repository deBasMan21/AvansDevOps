using AvansDevOps;
using AvansDevOps.SprintAbstraction;
using AvansDevOps.SprintState;
using AvansDevOps.SprintDeploymentState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainTests.SprintTests
{
    public class DeploymentStateTest
    {
        [Fact]
        public void NotReadyToDeploy_Can_Go_To_ReadyToDeploy()
        {
            // Arrange
            ReleaseSprint sprint = new ReleaseSprint(Name: "sprint1", StartDate: DateTime.Now, EndDate: DateTime.Now.AddDays(20));
            sprint.UpdateDeploymentState(new NotReadyToDeploy(sprint));


            // Act & Assert
            sprint.ApproveDeployment();
            Assert.True(sprint.deploymentState is ReadyToDeployState);
        }

        [Fact]
        public void NotReadyToDeploy_Can_Go_To_Ready_DeploymentCancelled()
        {
            // Arrange
            ReleaseSprint sprint = new ReleaseSprint(Name: "sprint1", StartDate: DateTime.Now, EndDate: DateTime.Now.AddDays(20));
            sprint.UpdateDeploymentState(new NotReadyToDeploy(sprint));


            // Act & Assert
            sprint.CancelDeployment();
            Assert.True(sprint.deploymentState is DeploymentCancelledState);
        }
    }
}
