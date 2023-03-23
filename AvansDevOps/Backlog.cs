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
        public Backlog() 
        {
            this.Items = new List<BacklogItem>();
        }

        public void Add(BacklogItem item) => Items.Add(item);
        public void Remove(BacklogItem item) => Items.Remove(item); 
    }
}
