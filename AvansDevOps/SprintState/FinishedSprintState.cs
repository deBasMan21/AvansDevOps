using AvansDevOps.SprintAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.SprintState
{
    public class FinishedSprintState : ISprintState
    {
        private readonly Sprint _sprint;

        public FinishedSprintState(Sprint Sprint) => this._sprint = Sprint;

        public void FinishSprint() { }

        public void ReviewSprint(bool approvedDeployement = false)
        {
            _sprint.UpdateSprintState(new ClosedSprintState(_sprint));

            if (_sprint is ReleaseSprint releaseSprint && approvedDeployement)
            {
                releaseSprint.ApproveDeployment();
            }
        }

        public void StartSprint() { }
    }
}