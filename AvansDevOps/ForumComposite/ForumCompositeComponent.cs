using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.ForumComposite
{
    public abstract class ForumCompositeComponent : ForumComponent
    {
        public List<ForumComponent> GetComponents() => GetChildrenComponents();

        public abstract List<ForumComponent> GetChildrenComponents();
        public abstract void AddChild(ForumComponent child);
        public abstract void RemoveChild(ForumComponent child);
        public abstract void ReplaceChild(ForumComponent child, ForumComponent oldChild);
        public abstract void AddMessage(ForumMessageComponent component);
    }
}
