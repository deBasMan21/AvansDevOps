using AvansDevOps.Pipeline;
using AvansDevOps.SprintAbstraction;
using AvansDevOps.UserAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainTests.NotificationTests
{
    public class DeploymentNotifications
    {
        [Fact]
        public void SMShouldBeNotifiedWhenDeploymentFailes()
        {
            // Arrange
            ScrumMaster scrumMaster = new ScrumMaster("");
            scrumMaster.AddNotificationPreference(AvansDevOps.Enums.NotificationType.EMAIL);

            ProductOwner productOwner = new ProductOwner("");
            productOwner.AddNotificationPreference(AvansDevOps.Enums.NotificationType.EMAIL);

            ReleaseSprint sprint = new ReleaseSprint("", DateTime.Now, DateTime.Now);
            sprint.AssignScrumMaster(scrumMaster);
            sprint.AssignProductOwner(productOwner);

            sprint.ApproveDeployment();
            sprint.StartDeployment(new DeploymentPipeline());

            // Act
            int result = sprint.FinishDeployment(false);

            // Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void SMAndPOShouldBeNotifiedWhenDeploymentSucceeds()
        {
            // Arrange
            ScrumMaster scrumMaster = new ScrumMaster("");
            scrumMaster.AddNotificationPreference(AvansDevOps.Enums.NotificationType.EMAIL);

            ProductOwner productOwner = new ProductOwner("");
            productOwner.AddNotificationPreference(AvansDevOps.Enums.NotificationType.EMAIL);

            ReleaseSprint sprint = new ReleaseSprint("", DateTime.Now, DateTime.Now);
            sprint.AssignScrumMaster(scrumMaster);
            sprint.AssignProductOwner(productOwner);

            sprint.ApproveDeployment();
            sprint.StartDeployment(new DeploymentPipeline());

            // Act
            int result = sprint.FinishDeployment(true);

            // Assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void SMAndPOShouldBeNotifiedWhenDeploymentIsCancelled()
        {
            // Arrange
            ScrumMaster scrumMaster = new ScrumMaster("");
            scrumMaster.AddNotificationPreference(AvansDevOps.Enums.NotificationType.EMAIL);

            ProductOwner productOwner = new ProductOwner("");
            productOwner.AddNotificationPreference(AvansDevOps.Enums.NotificationType.EMAIL);

            ReleaseSprint sprint = new ReleaseSprint("", DateTime.Now, DateTime.Now);
            sprint.AssignScrumMaster(scrumMaster);
            sprint.AssignProductOwner(productOwner);

            // Act
            int result = sprint.CancelDeployment();

            // Assert
            Assert.Equal(2, result);
        }
    }
}
