using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.BacklogItemState
{
    public class TodoState : IBacklogItemState
    {
        private IBacklogItemStateHolder _backlogItem;

        public TodoState(IBacklogItemStateHolder backlogItem)
        {
            _backlogItem = backlogItem;
        }

        public void StartTask()
        {
            _backlogItem.UpdateState(new DoingState(_backlogItem));
        }

        public void CloseTask()
        {
            Console.WriteLine("The backlog item needs to start first");
            return;
        }

        public void FinishTask()
        {
            Console.WriteLine("The backlog item needs to start first");
            return;
        }

        public void InvalidateTask()
        {
            Console.WriteLine("The backlog item needs to start first");
            return;
        }

        public void RetestTask()
        {
            Console.WriteLine("The backlog item needs to start first");
            return;
        }

        public void TestTask()
        {
            Console.WriteLine("The backlog item needs to start first");
            return;
        }
    }
}
