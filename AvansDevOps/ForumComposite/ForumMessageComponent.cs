using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.ForumComposite
{
    public class ForumMessageComponent : ForumComponent
    {
        private string message;
        public ForumMessageComponent(string message)
        {
            this.message = message;
        }

        public string GetMessage() => message;
    }
}
