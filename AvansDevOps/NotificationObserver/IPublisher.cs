using AvansDevOps.UserAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.NotificationObserver
{
    public interface IPublisher<in T> where T : ISubscriber
    {
        public void RegisterSubscriber(T Subscriber);
        public void RemoveSubscriber(T Subscriber);
        public int Notify(string message, Type? userType);
    }

    public interface IForumPublisher<in T> where T : ISubscriber
    {
        public void RegisterSubscriber(T Subscriber);
        public void RemoveSubscriber(T Subscriber);
        public int Notify(string message, User user);
    }
}
