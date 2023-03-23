using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Pipeline
{
    public interface IActionComponent
    {
        public void AcceptVisitor(IActionVisitor visitor);
    }
}
