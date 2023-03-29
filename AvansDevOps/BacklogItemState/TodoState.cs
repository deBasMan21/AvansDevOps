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

        public void StartTask()
        {
            _backlogItem.UpdateState(new DoingState(_backlogItem));
        }

        public void EvaluateTestRapport(bool passed)
        {
            return;
        }

        public int FinishTask()
        {
            return 0;
        }

        public void InvalidateTask()
        {
            return;
        }

        public int SendTestRapport(bool passed)
        {
            return 0;
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
