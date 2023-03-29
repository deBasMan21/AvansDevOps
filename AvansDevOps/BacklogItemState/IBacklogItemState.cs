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
        public void TestTask(bool success);
        public void InvalidateTask();
        public void CloseTask();
    }
}
