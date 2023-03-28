using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.BacklogItemState
{
    public interface IBacklogItemStateHolder
    {
        void UpdateState(IBacklogItemState newState);
    }
}
