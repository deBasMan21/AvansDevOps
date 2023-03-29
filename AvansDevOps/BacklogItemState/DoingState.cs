using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.BacklogItemState
{
    public class DoingState : IBacklogItemState
    {
        private IBacklogItemStateHolder _backlogItem;

        public DoingState(IBacklogItemStateHolder backlogItem)
        {
            _backlogItem = backlogItem;
        }

        public void FinishTask()
        {
            _backlogItem.UpdateState(new ReadyForTestingState(_backlogItem));
        }

        public void CloseTask()
        {
            Console.WriteLine("The backlog item has not finished yet");
            return;
        }

        public void InvalidateTask()
        {
            Console.WriteLine("The backlog item has not finished yet");
            return;
        }

        public void RetestTask()
        {
            Console.WriteLine("The backlog item has not finished yet");
            return;
        }

        public void StartTask()
        {
            Console.WriteLine("The backlog item is already in progress");
            return;
        }

        public void TestTask()
        {
            Console.WriteLine("The backlog item has not finished yet");
            return;
        }
    }
}
