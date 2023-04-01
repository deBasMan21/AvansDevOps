using AvansDevOps.UserAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.NotificationObserver
{
    public interface IPublisher
    {
        public void RegisterSubscriber(ISubscriber Subscriber);
        public void RemoveSubscriber(ISubscriber Subscriber);
        public int Notify(string message, Type? userType);
    }

    public interface IForumPublisher
    {
        public void RegisterSubscriber(ISubscriber Subscriber);
        public void RemoveSubscriber(ISubscriber Subscriber);
        public int Notify(string message, User user);
    }
}
