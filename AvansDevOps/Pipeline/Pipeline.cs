using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Pipeline
{
    public class PipeLine : PipeLineCompositeComponent
    {
        override public void AcceptVisitor(IPipeLineVisitor visitor)
        {
            visitor.VisitPipeline(this);
            base.AcceptVisitor(visitor);
        }

    }
}
