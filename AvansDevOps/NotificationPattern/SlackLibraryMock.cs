using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansDevOps.Enums;
using AvansDevOps.UserAbstraction;

namespace AvansDevOps.NotificationPattern
{
    public class SlackLibraryMock : ISlackLibrary
    {
        public bool SendNotification(string message, User user)
        {
            Console.WriteLine($"Send message to {user.Name} via Slack: {message}");
            return true;
        }
    }
}
