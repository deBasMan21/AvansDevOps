using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.BacklogItemState
{
    public class ReadyForTestingState : IBacklogItemState
    {

        private IBacklogItemStateHolder _backlogItemState;
        public ReadyForTestingState(IBacklogItemStateHolder _backlogItemState) { 
            this._backlogItemState = _backlogItemState;
        }

        public void TestTask()
        {
            _backlogItemState.UpdateState(new TestedState(_backlogItemState));
        }

        public void CloseTask()
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

        public void RetestTask()
        {
            return;
        }

        public void StartTask()
        {
            return;
        }

    }
}
