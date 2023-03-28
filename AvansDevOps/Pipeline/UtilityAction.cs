using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Pipeline
{
    public class UtilityAction : IActionComponent
    {

        public List<string> Actions { get; private set; }

        public UtilityAction(List<string> Actions)
        {
            this.Actions = Actions;
        }

        public void AcceptVisitor(IActionVisitor visitor)
        {
            visitor.VisitUtility(this);
        }

        public void RunUtilityActions()
        {
            foreach (var action in Actions)
            {
                Console.WriteLine($"Running action: {action}");
            }
        }
    }
}
