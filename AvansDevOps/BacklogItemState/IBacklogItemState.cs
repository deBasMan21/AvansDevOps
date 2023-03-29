﻿using System;
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
        public void StartTesting();
        public void SendTestRapport(bool passed);
        public void EvaluateTestRapport(bool passed);
        public void InvalidateTask();
    }
}
