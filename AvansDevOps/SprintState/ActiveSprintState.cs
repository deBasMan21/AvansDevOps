using AvansDevOps.SprintAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.SprintState
{
    public class ActiveSprintState : ISprintState
    {
        private Sprint _Sprint;

        public ActiveSprintState(Sprint Sprint)
        {
            this._Sprint = Sprint;
        }

        public void FinishSprint()
        {
            _Sprint.UpdateSprintState(new FinishedSprintState(_Sprint));
        }

        public void ReviewSprint()
        {
            throw new NotImplementedException();
        }

        public void StartSprint()
        {
            throw new NotImplementedException();
        }
    }
}