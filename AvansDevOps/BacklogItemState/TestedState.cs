using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.BacklogItemState
{
    public class TestedState : IBacklogItemState
    {
        private readonly BacklogItem _backlogItem;

        public TestedState(BacklogItem backlogItem) => _backlogItem = backlogItem;

        public void EvaluateTestRapport(bool passed)
        {
            if (passed)
            {
                _backlogItem.UpdateState(new DoneState(_backlogItem));
            }
            else
            {
                _backlogItem.UpdateState(new ReadyForTestingState(_backlogItem));
            }
        }

        public int FinishTask() => 0;

        public void InvalidateTask() => Console.WriteLine("Item needs to be evaluated..");

        public int SendTestRapport(bool passed) => 0;

        public void StartTask() => Console.WriteLine("Item needs to be evaluated..");

        public void StartTesting() => Console.WriteLine("Item needs to be evaluated..");
    }
}