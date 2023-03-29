using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.BacklogItemState
{
    public class DoingState : IBacklogItemState
    {
        private IBacklogItemStateHolder _backlogItem;

        public DoingState(IBacklogItemStateHolder backlogItem)
        {
            _backlogItem = backlogItem;
        }

        public void EvaluateTestRapport(bool passed)
        {
            return;
        }

        public void FinishTask()
        {
            _backlogItem.UpdateState(new ReadyForTestingState(_backlogItem));
        }

        public void InvalidateTask()
        {
            return;
        }

        public void SendTestRapport(bool passed)
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
