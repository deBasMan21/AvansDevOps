using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.BacklogItemState
{
    public class DoneState : IBacklogItemState
    {
        private readonly BacklogItem _backlogItem;

        public DoneState(BacklogItem backlogItem) => _backlogItem = backlogItem;

        public void InvalidateTask() => _backlogItem.UpdateState(new TodoState(_backlogItem));

        public void EvaluateTestRapport(bool passed) { }

        public int FinishTask() => 0;

        public int SendTestRapport(bool passed) => 0;

        public void StartTask() { }

        public void StartTesting() { }

        public void TestTask(bool success) { }

        public void CloseTask() => _backlogItem.UpdateState(new ClosedState(_backlogItem));
    }
}
