using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.BacklogItemState
{
    public class ReadyForTestingState : IBacklogItemState
    {
        private BacklogItem _backlogItem;

        private IBacklogItemStateHolder _backlogItemState;
        public ReadyForTestingState(IBacklogItemStateHolder _backlogItemState) { 
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

    }
}
