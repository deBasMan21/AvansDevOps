﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.BacklogItemState
{
    public class DoingState : IBacklogItemState
    {
        private readonly BacklogItem _backlogItem;

        public DoingState(BacklogItem backlogItem) => _backlogItem = backlogItem;

        public void EvaluateTestRapport(bool passed) { }

        public int FinishTask()
        {
            if (_backlogItem.Activities.All(a => a.IsFinished)) {
                _backlogItem.UpdateState(new ReadyForTestingState(_backlogItem));
                return _backlogItem.NotifyTesters();
            }

            Console.WriteLine("Finish all activities before finishing a sprint item");

            return 0;
        }

        public void InvalidateTask() { }

        public int SendTestRapport(bool passed) => 0;

        public void StartTask() { }

        public void StartTesting() { }
        public void CloseTask() { }
    }
}
