﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.SprintState
{
    public interface ISprintState
    {
        public void StartSprint();
        public void FinishSprint();
        public void ReviewSprint(bool approvedDeployement = false);
    }
}