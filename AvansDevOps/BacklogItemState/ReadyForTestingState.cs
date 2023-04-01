using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.BacklogItemState
{
    public class ReadyForTestingState : IBacklogItemState
    {
        private readonly BacklogItem _backlogItemState;
        public ReadyForTestingState(BacklogItem _backlogItemState) => this._backlogItemState = _backlogItemState;

        public void StartTesting() => _backlogItemState.UpdateState(new TestingState(_backlogItemState));

        public void EvaluateTestRapport(bool passed) => Console.WriteLine("Item needs to be tested..");

        public int FinishTask() => 0;

        public void InvalidateTask() => Console.WriteLine("Item needs to be tested..");

        public int SendTestRapport(bool passed) => 0;

        public void CloseTask() => Console.WriteLine("Item needs to be tested..");
        public void StartTask() => Console.WriteLine("Item needs to be tested..");
    }
}
