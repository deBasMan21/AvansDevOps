using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.BacklogItemState
{
    public class ReadyForTestingState : IBacklogItemState
    {
        private IBacklogItem _backlogItem;

        public ReadyForTestingState(IBacklogItem backlogItem)
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
            throw new NotImplementedException();
        }

        public void StartTask()
        {
            throw new NotImplementedException();
        }

        public void TestTask(bool success)
        {
            if (success)
            {
                _backlogItem.UpdateState(new TestedState(_backlogItem));
            } else
            {
                _backlogItem.UpdateState(new TodoState(_backlogItem));
            }
        }
    }
}
