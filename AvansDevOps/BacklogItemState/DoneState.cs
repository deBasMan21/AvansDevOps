using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.BacklogItemState
{
    public class DoneState : IBacklogItemState
    {
        private IBacklogItemStateHolder _backlogItem;

        public DoneState(IBacklogItemStateHolder backlogItem)
        {
            _backlogItem = backlogItem;
        }

        public void CloseTask()
        {
            throw new NotImplementedException();
        }

        public void FinishTask()
        {
            throw new NotImplementedException();
        }

        public void InvalidateTask()
        {
            _backlogItem.UpdateState(new TodoState(_backlogItem));
        }

        public void StartTask()
        {
            throw new NotImplementedException();
        }
    }
}
