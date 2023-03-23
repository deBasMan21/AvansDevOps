using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Pipeline
{
    public class DeployAction : IActionComponent
    {

        public string DeploymentTarget { get; private set; }

        public DeployAction(string DeploymentTarget)
        {
            this.DeploymentTarget = DeploymentTarget;
        }

        public void AcceptVisitor(IActionVisitor visitor)
        {
            visitor.VisitDeploy(this);
        }

        public void RunDeployment()
        {
            Console.WriteLine($"Deploying to {DeploymentTarget}");
        }

    }
}
