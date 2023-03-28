using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansDevOps.Enums;

namespace AvansDevOps.UserAbstraction
{
    public abstract class User
    {
        public string Name { get; private set; }
        public List<NotificationType> NotificationPreferences { get; private set; } = new();

        public User(string Name)
        {
            this.Name = Name;
        }

        public void AddNotificationPreference(NotificationType type)
        {
            NotificationPreferences.Add(type);
        }
    }
}
