using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.BacklogItemState
{
    public class TestedState : IBacklogItemState
    {
        private BacklogItem _backlogItem;

        public TestedState(BacklogItem backlogItem)
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