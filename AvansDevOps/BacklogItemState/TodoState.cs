using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.BacklogItemState
{
    public class TodoState : IBacklogItemState
    {
        private IBacklogItemStateHolder _backlogItem;

        public TodoState(IBacklogItemStateHolder backlogItem)
        {
            _backlogItem = backlogItem;
        }

        public void StartTask()
        {
            _backlogItem.UpdateState(new DoingState(_backlogItem));
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

        public void SendTestRapport(bool passed)
        {
            return;
        }

        public void StartTesting()
        {
            return;
        }

        public void TestTask(bool success)
        {
            throw new NotImplementedException();
        }
    }
}
