﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansDevOps.Enums;
using AvansDevOps.UserAbstraction;

namespace AvansDevOps.NotificationAdapter
{
    public class SlackLibraryMock : ISlackLibrary
    {
        public void SendNotification(string message, User user)
        {
            Console.WriteLine($"Send message to {user.Name} via Slack: {message}");
        }
    }
}