using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.BacklogItemState
{
    public class TodoState : IBacklogItemState
    {
        private readonly BacklogItem _backlogItem;

        public TodoState(BacklogItem backlogItem) => _backlogItem = backlogItem;

        public void StartTask() => _backlogItem.UpdateState(new DoingState(_backlogItem));

        public void EvaluateTestRapport(bool passed) => Console.WriteLine("Item needs to be started..");

        public int FinishTask() => 0;

        public void InvalidateTask() => Console.WriteLine("Item needs to be started..");

        public int SendTestRapport(bool passed) => 0;

        public void CloseTask() => Console.WriteLine("Item needs to be started..");
        public void StartTesting() => Console.WriteLine("Item needs to be started..");
    }
}
