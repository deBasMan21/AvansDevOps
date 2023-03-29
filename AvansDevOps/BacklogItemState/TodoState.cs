using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.BacklogItemState
{
    public class TodoState : IBacklogItemState
    {
        private BacklogItem _backlogItem;

        public TodoState(BacklogItem backlogItem)
        {
            _backlogItem = backlogItem;
        }

        public void CloseTask()
        {
            throw new NotImplementedException();
        }

        public int FinishTask()
        {
            throw new NotImplementedException();
        }

        public void InvalidateTask()
        {
            throw new NotImplementedException();
        }

        public void StartTask()
        {
            _backlogItem.UpdateState(new InProgressState(_backlogItem));
        }

        public void TestTask(bool success)
        {
            throw new NotImplementedException();
        }
    }
}
