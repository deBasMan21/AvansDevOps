using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansDevOps.Enums;
using AvansDevOps.UserAbstraction;

namespace AvansDevOps.NotificationAdapter
{
    public interface IEmailLibrary
    {
        public void SendNotification(String message, User user);
    }
}
