using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Pipeline
{
    public class BuildAction : IActionComponent
    {

        public string BuildType { get; private set; }

        public BuildAction(string BuildType)
        {
            this.BuildType = BuildType; 
        }

        public void AcceptVisitor(IActionVisitor visitor)
        {
            visitor.VisitBuild(this);
        }

        public void RunBuild()
        {
            Console.WriteLine($"Running build {BuildType}");
        }

    }
}
