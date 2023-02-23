using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Pipeline
{
    public class PipeLineCompositeComponent: IPipeLineComponent
    {
        private List<IPipeLineComponent> _parts;

        public PipeLineCompositeComponent()
        {
            _parts= new List<IPipeLineComponent>();
        }

        public void AddComponent(IPipeLineComponent PipeLineComponent)
        {
            _parts.Add(PipeLineComponent);
        }

        virtual public void AcceptVisitor(IPipeLineVisitor visitor)
        {
            foreach (var part in _parts)
            {
                part.AcceptVisitor(visitor);
            }
        }
    }
}
