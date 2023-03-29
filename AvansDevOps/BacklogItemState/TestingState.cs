using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.BacklogItemState
{
    public class TestingState : IBacklogItemState
    {

        private IBacklogItemStateHolder _backlogItem;

        public TestingState(IBacklogItemStateHolder backlogItem)
        {
            _backlogItem = backlogItem;
        }

        public void SendTestRapport(bool passed)
        {
            if (passed)
            {
                _backlogItem.UpdateState(new TestedState(_backlogItem));
            }
            else {
                _backlogItem.UpdateState(new TodoState(_backlogItem));
            }
        }

        public void EvaluateTestRapport(bool passed)
        {
            return;
        }

        public void FinishTask()
        {
            return;
        }

        public void InvalidateTask()
        {
            return;
        }

        public void StartTask()
        {
            return;
        }

        public void StartTesting()
        {
            return;
        }
    }
}
