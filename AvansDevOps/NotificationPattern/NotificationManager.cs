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
        private readonly IEmailLibrary _emailLibrary = new EmailLibraryMock();
        private readonly ISlackLibrary _slackLibrary = new SlackLibraryMock();

        public int SendNotification(string message, User user)
        {
            return user
                .NotificationPreferences
                .Select(p => SendToLibrary(message, p, user))
                .Count();
        }

        private bool SendToLibrary(string message, NotificationType type, User user) 
        {
            switch (type)
            {
                case NotificationType.EMAIL:
                    return _emailLibrary.SendNotification(message, user);
                case NotificationType.SLACK:
                    return _slackLibrary.SendNotification(message, user);
                default:
                    return false;
            }
        }
    }
}
