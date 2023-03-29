using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.BacklogItemState
{
    public class InProgressState : IBacklogItemState
    {
        private BacklogItem _backlogItem;

        public InProgressState(BacklogItem backlogItem)
        {
            _backlogItem = backlogItem;
        }

        public void CloseTask()
        {
            throw new NotImplementedException();
        }

        public int FinishTask()
        {
            _backlogItem.UpdateState(new ReadyForTestingState(_backlogItem));
            return _backlogItem.NotifyTesters();
        }

        public void InvalidateTask()
        {
            _backlogItem.UpdateState(new TodoState(_backlogItem));
        }

        public void StartTask()
        {
            throw new NotImplementedException();
        }

        public void TestTask(bool success)
        {
            throw new NotImplementedException();
        }
    }
}
