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
            Console.WriteLine("The backlog item needs to be tested first");
            return;
        }

        public void FinishTask()
        {
            Console.WriteLine("The backlog item needs to be tested first");
            return;
        }

        public void InvalidateTask()
        {
            Console.WriteLine("The backlog item needs to be tested first");
            return;
        }

        public void RetestTask()
        {
            Console.WriteLine("The backlog item needs to be tested first");
            return;
        }

        public void StartTask()
        {
            Console.WriteLine("The backlog item is already ready for testing");
            return;
        }

    }
}
