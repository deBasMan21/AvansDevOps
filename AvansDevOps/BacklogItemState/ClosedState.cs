using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.BacklogItemState
{
    public class ClosedState : IBacklogItemState
    {
        private readonly BacklogItem _backlogItem;

        public ClosedState(BacklogItem backlogItem)
        {
            _backlogItem = backlogItem;
            _backlogItem.Forum?.CloseForum();
        }

        public void CloseTask() => Console.WriteLine("Item has already been closed..");

        public void EvaluateTestRapport(bool passed) => Console.WriteLine("Item has already been closed..");

        public int FinishTask() => 0;

        public void InvalidateTask() => Console.WriteLine("Item has already been closed..");

        public int SendTestRapport(bool passed) => 0;

        public void StartTask() => Console.WriteLine("Item has already been closed..");

        public void StartTesting() => Console.WriteLine("Item has already been closed..");
    }
}
