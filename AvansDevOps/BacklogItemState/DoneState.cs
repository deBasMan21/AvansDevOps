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

        public void InvalidateTask()
        {
            _backlogItem.UpdateState(new TodoState(_backlogItem));
        }

        public void CloseTask()
        {
            return;
        }

        public void FinishTask()
        {
            return;
        }

        public void RetestTask()
        {
            return;
        }

        public void StartTask()
        {
            return;
        }

        public void TestTask()
        {
            return;
        }
    }
}
