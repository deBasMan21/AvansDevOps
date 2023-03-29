using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps
{
    public class Backlog
    {
        public List<BacklogItem> Items;
        private Func<string, Type, bool>? notificationCallback;
        public Backlog(Func<string, Type, bool>? notificationCallback) 
        {
            this.notificationCallback = notificationCallback;
            this.Items = new List<BacklogItem>();
        }

        public void Add(BacklogItem item)
        {
            item.SetNotificationCallback(notificationCallback);
            Items.Add(item);
        }
        public void Remove(BacklogItem item) => Items.Remove(item); 
    }
}
