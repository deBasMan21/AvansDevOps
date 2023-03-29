﻿using System;
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
            return;
        }

        public void FinishTask()
        {
            return;
        }

        public void InvalidateTask()
        {
            return;
        }

        public void RetestTask()
        {
            return;
        }

        public void TestTask()
        {
            return;
        }
    }
}
