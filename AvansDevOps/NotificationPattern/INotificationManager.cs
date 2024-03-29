﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansDevOps.Enums;
using AvansDevOps.UserAbstraction;

namespace AvansDevOps.NotificationPattern
{
    public interface INotificationManager
    {
        public int SendNotification(string message, User user);
    }
}
