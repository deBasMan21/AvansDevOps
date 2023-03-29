using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.BacklogItemState
{
    public class TestedState : IBacklogItemState
    {
        private IBacklogItemStateHolder _backlogItem;

        public TestedState(IBacklogItemStateHolder backlogItem)
        {
            _backlogItem = backlogItem;
        }

        public void EvaluateTestRapport(bool passed)
        {
            if (passed)
            {
                _backlogItem.UpdateState(new DoneState(_backlogItem));
            }
            else 
            {
                _backlogItem.UpdateState(new ReadyForTestingState(_backlogItem));
            }
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
