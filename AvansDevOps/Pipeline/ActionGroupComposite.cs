using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Pipeline
{
    public class ActionGroupComposite: IActionComponent
    {
        private List<IActionComponent> _parts;

        public ActionGroupComposite()
        {
            _parts= new List<IActionComponent>();
        }

        public void AddComponent(IActionComponent PipeLineComponent)
        {
            _parts.Add(PipeLineComponent);
        }

        virtual public void AcceptVisitor(IActionVisitor visitor)
        {
            foreach (var part in _parts)
            {
                part.AcceptVisitor(visitor);
            }
        }
    }
}
