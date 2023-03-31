using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansDevOps.SprintAbstraction;


namespace AvansDevOps.SprintState
{
    public class ActiveSprintState : ISprintState
    {
        private readonly Sprint _sprint;

        public ActiveSprintState(Sprint Sprint) => this._sprint = Sprint;

        public void FinishSprint() => _sprint.UpdateSprintState(new FinishedSprintState(_sprint));

        public void ReviewSprint(bool approvedDeployement = false) => Console.WriteLine("Sprint needs to finish..");

        public void StartSprint() => Console.WriteLine("Sprint needs to finish..");
    }
}