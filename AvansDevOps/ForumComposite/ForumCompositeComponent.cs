using AvansDevOps.NotificationObserver;
using AvansDevOps.UserAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.ForumComposite
{
    public abstract class ForumCompositeComponent : ForumComponent, IForumPublisher<User>
    {
        public List<ForumComponent> GetComponents() => GetChildrenComponents();

        public abstract List<ForumComponent> GetChildrenComponents();
        public abstract void AddChild(ForumComponent child);
        public abstract void RemoveChild(ForumComponent child);
        public abstract void ReplaceChild(ForumComponent child, ForumComponent oldChild);
        public abstract int AddMessage(ForumMessageComponent component);


        // Notification publisher
        private HashSet<User> subscribers = new HashSet<User>();

        public void RegisterSubscriber(User Subscriber) => subscribers.Add(Subscriber);

        public void RemoveSubscriber(User Subscriber) => subscribers.Remove(Subscriber);

        public int Notify(string message, User user) => subscribers.Where(u => u != user).Select(u => u.ReceiveUpdate(message)).Sum();
    }
}
