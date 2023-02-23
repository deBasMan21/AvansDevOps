using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Pipeline
{
    public class PipeLineCompositeComponent: IPipeLineComponent
    {
        private List<IPipeLineComponent> parts;

        public void AddComponent(IPipeLineComponent PipeLineComponent)
        {
            parts.Add(PipeLineComponent);
        }

        public void AcceptVisitor(IPipeLineVisitor visitor)
        {
            foreach (var part in parts)
            {
                part.AcceptVisitor(visitor);
            }
        }

    }
}
