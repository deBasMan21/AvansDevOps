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
        private Sprint _sprint;

        public ActiveSprintState(Sprint Sprint)
        {
            this._sprint = Sprint;
        }

        public void FinishSprint()
        {
            _sprint.UpdateSprintState(new FinishedSprintState(_sprint));
        }

        public void ReviewSprint(bool approvedDeployement = false)
        {
            return;
        }

        public void StartSprint()
        {
            return;
        }
    }
}