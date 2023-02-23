using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Pipeline
{
    public class DeployAction : IPipeLineComponent
    {
        public void AcceptVisitor(IPipeLineVisitor visitor)
        {
            visitor.VisitDeploy(this);
        }
    }
}
