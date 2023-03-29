using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansDevOps.Enums;
using AvansDevOps.NotificationObserver;
using AvansDevOps.NotificationPattern;

namespace AvansDevOps.UserAbstraction
{
    public abstract class User: ISubscriber
    {
        public string Name { get; private set; }
        public List<NotificationType> NotificationPreferences { get; private set; } = new();
        private INotificationManager notificationManager;

        public User(string Name)
        {
            this.Name = Name;
            notificationManager = new NotificationAdapter();
        }

        public void AddNotificationPreference(NotificationType type)
        {
            NotificationPreferences.Add(type);
        }

        public virtual int ReceiveUpdate(string message)
        {
            return notificationManager.SendNotification(message, this);
        }
    }
}
