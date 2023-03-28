using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansDevOps.SprintAbstraction;

namespace AvansDevOps.SprintState
{
    public class ClosedSprintState : ISprintState
    {
        private Sprint _sprint;

        public ClosedSprintState(Sprint Sprint)
        {
            this._sprint = Sprint;
        }

        public void FinishSprint()
        {
            return;
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