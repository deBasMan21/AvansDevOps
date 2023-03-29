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
        public void FinishTask();
        public void TestTask();
        public void RetestTask();
        public void InvalidateTask();
        public void CloseTask();
    }
}
