using AvansDevOps.NotificationObserver;
using AvansDevOps.UserAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.ForumComposite
{
    public class ForumThreadComponent : ForumCompositeComponent
    {
        private readonly ForumMessageComponent message;
        private readonly List<IForumComponent> children;

        public ForumThreadComponent(ForumMessageComponent message)
        {
            this.message = message;
            children = new List<IForumComponent>();

            RegisterSubscriber(message.creator);
        } 

        public override void AddChild(IForumComponent child) => children.Add(child);
        public override void RemoveChild(IForumComponent child) => children.Remove(child);
        public override void ReplaceChild(IForumComponent child, IForumComponent oldChild)
        {
            RemoveChild(oldChild);
            AddChild(child);
        }

        public override List<IForumComponent> GetChildrenComponents() => children;

        public override int AddMessage(ForumMessageComponent component)
        {
            if (!Editable) { return 0; }
            component.SetParent(this);
            AddChild(component);
            int result = Notify($"{component.creator.Name} posted a message: {component.message}", component.creator);
            RegisterSubscriber(component.creator);
            return result;
        }

        public override string GetMessage() => message.message;
    }
}
