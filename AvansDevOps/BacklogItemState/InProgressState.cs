using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.BacklogItemState
{
    public class InProgressState : IBacklogItemState
    {
        private IBacklogItem _backlogItem;

        public InProgressState(IBacklogItem backlogItem)
        {
            _backlogItem = backlogItem;
        }

        public void CloseTask()
        {
            throw new NotImplementedException();
        }

        public void FinishTask()
        {
            _backlogItem.UpdateState(new InTestingState(_backlogItem));
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
