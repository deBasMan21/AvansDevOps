﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.BacklogItemState
{
    public class TestingState : IBacklogItemState
    {

        private readonly BacklogItem _backlogItem;

        public TestingState(BacklogItem backlogItem) =>_backlogItem = backlogItem;

        public int SendTestRapport(bool passed)
        {
            if (passed)
            {
                _backlogItem.UpdateState(new TestedState(_backlogItem));
                return 0;
            }
            else {
                _backlogItem.UpdateState(new TodoState(_backlogItem));
                return _backlogItem.NotifyScrumMaster();
            }
        }

        public void EvaluateTestRapport(bool passed) { }

        public int FinishTask() => 0;

        public void InvalidateTask() { }

        public void StartTask() { }

        public void StartTesting() { }
        public void CloseTask() { }
    }
}
