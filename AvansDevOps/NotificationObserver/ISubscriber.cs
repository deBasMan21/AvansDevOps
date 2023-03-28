using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.NotificationObserver
{
    public interface ISubscriber
    {
        public void ReceiveUpdate(string message);
    }
}
