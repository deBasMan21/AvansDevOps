using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Pipeline
{
    public class DeploymentPipeline : ActionGroupComposite
    {
        private readonly string _name = "pipeline";
        override public bool AcceptVisitor(IActionVisitor visitor) => visitor.VisitPipeline(this) && base.AcceptVisitor(visitor);

        public bool StartPipeline() {
            Console.WriteLine($"-- Run {_name} --");
            return true;
        }

    }
}
