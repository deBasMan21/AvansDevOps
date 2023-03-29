using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.BacklogItemState
{
    public class TestedState : IBacklogItemState
    {
        private IBacklogItemStateHolder _backlogItem;

        public TestedState(IBacklogItemStateHolder backlogItem)
        {
            _backlogItem = backlogItem;
        }

        public void CloseTask()
        {
            _backlogItem.UpdateState(new DoneState(_backlogItem));
        }

        public void InvalidateTask()
        {
            _backlogItem.UpdateState(new TodoState(_backlogItem));
        }

        public void RetestTask()
        {
            _backlogItem.UpdateState(new ReadyForTestingState(_backlogItem));
        }

        public void FinishTask()
        {
            Console.WriteLine("The backlog item finished has already been tested");
            return;
        }

        public void StartTask()
        {
            Console.WriteLine("The backlog item finished has already been tested");
            return;
        }

        public void TestTask()
        {
            Console.WriteLine("The backlog item finished has already been tested");
            return;
        }
    }
}
