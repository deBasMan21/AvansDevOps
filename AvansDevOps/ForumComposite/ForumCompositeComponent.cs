using AvansDevOps.NotificationObserver;
using AvansDevOps.UserAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.ForumComposite
{
    public abstract class ForumCompositeComponent : IForumComponent, IForumPublisher<User>
    {
        protected bool Editable = true;
        public List<IForumComponent> GetComponents() => GetChildrenComponents();

        public abstract List<IForumComponent> GetChildrenComponents();
        public abstract void AddChild(IForumComponent child);
        public abstract void RemoveChild(IForumComponent child);
        public abstract void ReplaceChild(IForumComponent child, IForumComponent oldChild);
        public abstract int AddMessage(ForumMessageComponent component);
        public abstract string GetMessage();

        public void CloseForum()
        {
            Editable = false;
            GetChildrenComponents().ForEach(c => c.CloseForum());
        }

        // Notification publisher
        private readonly HashSet<User> subscribers = new HashSet<User>();

        public void RegisterSubscriber(User Subscriber) => subscribers.Add(Subscriber);

        public void RemoveSubscriber(User Subscriber) => subscribers.Remove(Subscriber);

        public int Notify(string message, User user) => subscribers.Where(u => u != user).Select(u => u.ReceiveUpdate(message)).Sum();
    }
}
