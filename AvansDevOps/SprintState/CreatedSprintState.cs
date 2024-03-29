﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansDevOps.SprintAbstraction;

namespace AvansDevOps.SprintState
{
    public class CreatedSprintState: ISprintState
    {
        private readonly Sprint _sprint;

        public CreatedSprintState(Sprint Sprint) => this._sprint = Sprint;

        public void FinishSprint() => Console.WriteLine("Sprint needs to be started..");

        public void ReviewSprint(bool approvedDeployement = false) => Console.WriteLine("Sprint needs to be started..");

        public void StartSprint() => _sprint.UpdateSprintState(new ActiveSprintState(_sprint));
    }
}