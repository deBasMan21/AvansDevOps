using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.ForumComposite
{
    public class ForumThreadComponent : ForumCompositeComponent
    {
        private ForumMessageComponent message;
        private List<ForumComponent> children;

        public ForumThreadComponent(ForumMessageComponent message)
        {
            this.message = message;
            children = new List<ForumComponent>();
        } 

        public override void AddChild(ForumComponent child) => children.Add(child);
        public override void RemoveChild(ForumComponent child) => children.Remove(child);
        public override void ReplaceChild(ForumComponent child, ForumComponent oldChild)
        {
            RemoveChild(oldChild);
            AddChild(child);
        }

        public override List<ForumComponent> GetChildrenComponents() => children;

        public override void AddMessage(ForumMessageComponent component)
        {
            component.SetParent(this);
            AddChild(component);
        }
    }
}
