using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansDevOps.Enums;
using AvansDevOps.UserAbstraction;

namespace AvansDevOps.NotificationPattern
{
    public class NotificationAdapter : INotificationManager
    {
        private IEmailLibrary _emailLibrary = new EmailLibraryMock();
        private ISlackLibrary _slackLibrary = new SlackLibraryMock();

        public void SendNotification(string message, User user)
        {
            foreach (NotificationType type in user.NotificationPreferences)
            {
                switch (type)
                {
                    case NotificationType.EMAIL:
                        _emailLibrary.SendNotification(message, user);
                        break;
                    case NotificationType.SLACK:
                        _slackLibrary.SendNotification(message, user);
                        break;
                }
            }
        }
    }
}
