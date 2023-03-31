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

        public void EvaluateTestRapport(bool passed) => Console.WriteLine("Item has already finished..");

        public int FinishTask() => 0;

        public int SendTestRapport(bool passed) => 0;

        public void StartTask() => Console.WriteLine("Item has already finished..");

        public void StartTesting() => Console.WriteLine("Item has already finished..");

        public void TestTask(bool success) => Console.WriteLine("Item has already finished..");

        public void CloseTask() => _backlogItem.UpdateState(new ClosedState(_backlogItem));
    }
}
