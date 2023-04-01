using AvansDevOps.SprintAbstraction;
using AvansDevOps.SprintDeploymentState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using AvansDevOps.Pipeline;

namespace DomainTests.SprintTests
{
    public class PipelineTests
    {

        [Fact]
        public void All_Actions_Succeeds_Should_Succeed_The_Pipeline()
        {
            // Arrange
            ReleaseSprint sprint = new ReleaseSprint(Name: "sprint1", StartDate: DateTime.Now, EndDate: DateTime.Now.AddDays(20));
            sprint.UpdateDeploymentState(new ReadyToDeployState(sprint));

            DeploymentPipeline pipeline = new();

            var sourcesAction = new Mock<SourcesAction>("ThisIsSupposeToBeAnUrls");
            var packageAction = new Mock<PackageAction>(new List<string> { "xunit (2.4.2)", "Moq (4.18.4)" });
            var buildAction = new Mock<BuildAction>(".NET Core build");
            var testAction = new Mock<TestAction>("XUnit 2.4.2");
            var analyseAction = new Mock<AnalyseAction>("SonarQube");
            var deployAction = new Mock<DeployAction>("Azure");
            var utilityAction = new Mock<UtilityAction>(new List<string> { "UtilityAction1", "UtilityAction2" });

            sourcesAction.Setup(p => p.CloneRepo()).Returns(true);
            packageAction.Setup(p => p.InstallDependencies()).Returns(true);
            buildAction.Setup(p => p.RunBuild()).Returns(true);
            testAction.Setup(p => p.RunTests()).Returns(true);
            testAction.Setup(p => p.PublishResults()).Returns(true);
            analyseAction.Setup(p => p.RunAnalysis()).Returns(true);
            deployAction.Setup(p => p.RunDeployment()).Returns(true);
            utilityAction.Setup(p => p.RunUtilityActions()).Returns(true);

            pipeline.AddComponent(sourcesAction.Object);
            pipeline.AddComponent(packageAction.Object);
            pipeline.AddComponent(buildAction.Object);
            pipeline.AddComponent(testAction.Object);
            pipeline.AddComponent(analyseAction.Object);
            pipeline.AddComponent(deployAction.Object);
            pipeline.AddComponent(utilityAction.Object);

            // Act
            bool hasSucceeded = sprint.StartDeployment(pipeline);

            // Assert
            Assert.True(hasSucceeded);
        }

        [Theory]
        [InlineData(false, true, true, true, true, true, true, true)]
        [InlineData(true, false, true, true, true, true, true, true)]
        [InlineData(true, true, false, true, true, true, true, true)]
        [InlineData(true, true, true, false, true, true, true, true)]
        [InlineData(true, true, true, true, false, true, true, true)]
        [InlineData(true, true, true, true, true, false, true, true)]
        [InlineData(true, true, true, true, true, true, false, true)]
        [InlineData(true, true, true, true, true, true, true, false)]

        public void One_Action_Failing_Should_Fail_The_Pipeline(bool sources, bool package, bool build, bool tests, bool publishresults, bool analyse, bool deploy, bool utility)
        {
            // Arrange
            ReleaseSprint sprint = new ReleaseSprint(Name: "sprint1", StartDate: DateTime.Now, EndDate: DateTime.Now.AddDays(20));
            sprint.UpdateDeploymentState(new ReadyToDeployState(sprint));

            DeploymentPipeline pipeline = new();

            var sourcesAction = new Mock<SourcesAction>("ThisIsSupposeToBeAnUrls");
            var packageAction = new Mock<PackageAction>(new List<string> { "xunit (2.4.2)", "Moq (4.18.4)" });
            var buildAction = new Mock<BuildAction>(".NET Core build");
            var testAction = new Mock<TestAction>("XUnit 2.4.2");
            var analyseAction = new Mock<AnalyseAction>("SonarQube");
            var deployAction = new Mock<DeployAction>("Azure");
            var utilityAction = new Mock<UtilityAction>(new List<string> { "UtilityAction1", "UtilityAction2" });

            sourcesAction.Setup(p => p.CloneRepo()).Returns(sources);
            packageAction.Setup(p => p.InstallDependencies()).Returns(package);
            buildAction.Setup(p => p.RunBuild()).Returns(build);
            testAction.Setup(p => p.RunTests()).Returns(tests);
            testAction.Setup(p => p.PublishResults()).Returns(publishresults);
            analyseAction.Setup(p => p.RunAnalysis()).Returns(analyse);
            deployAction.Setup(p => p.RunDeployment()).Returns(deploy);
            utilityAction.Setup(p => p.RunUtilityActions()).Returns(utility);

            pipeline.AddComponent(sourcesAction.Object);
            pipeline.AddComponent(packageAction.Object);
            pipeline.AddComponent(buildAction.Object);
            pipeline.AddComponent(testAction.Object);
            pipeline.AddComponent(analyseAction.Object);
            pipeline.AddComponent(deployAction.Object);
            pipeline.AddComponent(utilityAction.Object);

            // Act
            bool hasSucceeded = sprint.StartDeployment(pipeline);

            // Assert
            Assert.True(!hasSucceeded);
        }

    }
}
