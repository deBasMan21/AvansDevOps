using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.ForumComposite
{
    public abstract class ForumComponent
    {
        protected string _message { get; set; }

        public ForumComponent(string message)
        {
            _message = message;
        }

        public abstract string GetComment();

        public virtual void AddChild(ForumComponent component)
        {
            throw new NotImplementedException();
        }

        public virtual void RemoveChild(ForumComponent component)
        {
            throw new NotImplementedException();
        }

        public virtual ForumComponent GetChild(int index)
        {
            throw new NotImplementedException();
        }
    }
}
