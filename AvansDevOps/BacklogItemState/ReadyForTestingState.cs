using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.BacklogItemState
{
    public class ReadyForTestingState : IBacklogItemState
    {
        private BacklogItem _backlogItemState;
        public ReadyForTestingState(BacklogItem _backlogItemState) { 
            this._backlogItemState = _backlogItemState;
        }

        public void StartTesting()
        {
            _backlogItemState.UpdateState(new TestingState(_backlogItemState));
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

        public void StartTask()
        {
            return;
        }

    }
}
