using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.BacklogItemState
{
    public class DoneState : IBacklogItemState
    {
        private IBacklogItemStateHolder _backlogItem;

        public DoneState(IBacklogItemStateHolder backlogItem)
        {
            _backlogItem = backlogItem;
        }

        public void InvalidateTask()
        {
            _backlogItem.UpdateState(new TodoState(_backlogItem));
        }

        public void CloseTask()
        {
            Console.WriteLine("The backlog item is already closed");
            return;
        }

        public void FinishTask()
        {
            Console.WriteLine("The backlog item is already closed");
            return;
        }

        public void RetestTask()
        {
            Console.WriteLine("The backlog item is already closed");
            return;
        }

        public void StartTask()
        {
            Console.WriteLine("The backlog item is already closed");
            return;
        }

        public void TestTask()
        {
            Console.WriteLine("The backlog item is already closed");
            return;
        }
    }
}
