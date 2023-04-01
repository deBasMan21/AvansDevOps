using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Pipeline
{
    public class ActionGroupComposite: IActionComponent
    {
        private readonly List<IActionComponent> _parts;

        public ActionGroupComposite()
        {
            _parts= new List<IActionComponent>();
        }

        public void AddComponent(IActionComponent PipeLineComponent)
        {
            _parts.Add(PipeLineComponent);
        }

        virtual public bool AcceptVisitor(IActionVisitor visitor)
        {
            bool succeeded = true;
            foreach (var part in _parts)
            {
                if (!part.AcceptVisitor(visitor)) { 
                    succeeded = false;
                    return succeeded;
                }
            }
            return succeeded;
        }
    }
}
