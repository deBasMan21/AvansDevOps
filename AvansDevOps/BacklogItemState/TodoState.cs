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

        public TodoState(BacklogItem backlogItem) => _backlogItem = backlogItem;

        public void StartTask() => _backlogItem.UpdateState(new DoingState(_backlogItem));

        public void EvaluateTestRapport(bool passed) { }

        public int FinishTask() => 0;

        public void InvalidateTask() { }

        public int SendTestRapport(bool passed) => 0;

        public void StartTesting() { }

        public void TestTask(bool success) { }
    }
}
