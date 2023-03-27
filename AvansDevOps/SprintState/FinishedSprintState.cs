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
        private Sprint _Sprint;

        public FinishedSprintState(Sprint Sprint)
        {
            this._Sprint = Sprint;
        }

        public void FinishSprint()
        {
            throw new NotImplementedException();
        }

        public void ReviewSprint()
        {
            _Sprint.UpdateSprintState(new ClosedSprintState(_Sprint));
        }

        public void StartSprint()
        {
            throw new NotImplementedException();
        }
    }
}