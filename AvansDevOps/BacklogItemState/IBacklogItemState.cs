using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.BacklogItemState
{
    public interface IBacklogItemState
    {
        public void StartTask();
        public int FinishTask();
        public void StartTesting();
        public int SendTestRapport(bool passed);
        public void EvaluateTestRapport(bool passed);
        public void InvalidateTask();
        public void CloseTask();
    }
}
