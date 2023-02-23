using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.BacklogItemState
{
    public interface IBacklogItem
    {
        void UpdateState(IBacklogItemState newState);
    }
}
