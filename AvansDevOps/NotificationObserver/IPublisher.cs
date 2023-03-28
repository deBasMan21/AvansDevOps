using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.NotificationObserver
{
    public interface IPublisher<T> where T : ISubscriber
    {
        public void RegisterSubscriber(T Subscriber);
        public void RemoveSubscriber(T Subscriber);
        public bool Notify(string message);
    }
}
