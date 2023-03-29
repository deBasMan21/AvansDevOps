﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.BacklogItemState
{
    public class DoingState : IBacklogItemState
    {
        private BacklogItem _backlogItem;

        public DoingState(BacklogItem backlogItem)
        {
            _backlogItem = backlogItem;
        }

        public void EvaluateTestRapport(bool passed)
        {
            return;
        }

        public int FinishTask()
        {
            _backlogItem.UpdateState(new ReadyForTestingState(_backlogItem));
            return _backlogItem.NotifyTesters();
        }

        public void InvalidateTask()
        {
            return;
        }

        public int SendTestRapport(bool passed)
        {
            return 0;
        }

        public void StartTask()
        {
            return;
        }

        public void StartTesting()
        {
            return;
        }
    }
}
