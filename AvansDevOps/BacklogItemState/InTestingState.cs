using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.BacklogItemState
{
    public class InTestingState : IBacklogItemState
    {
        private IBacklogItem _backlogItem;

        public InTestingState(IBacklogItem backlogItem)
        {
            _backlogItem = backlogItem;
        }

        public void CloseTask()
        {
            _backlogItem.UpdateState(new DoneState(_backlogItem));
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

        public void TestTask()
        {
            throw new NotImplementedException();
        }
    }
}
