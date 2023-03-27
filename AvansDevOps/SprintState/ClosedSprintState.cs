using AvansDevOps.SprintAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.SprintState
{
    public class ClosedSprintState : ISprintState
    {
        private Sprint _Sprint;

        public ClosedSprintState(Sprint Sprint)
        {
            this._Sprint = Sprint;
        }

        public void StartSprint()
        {
            throw new NotImplementedException();

        }
        public void FinishSprint()
        {
            throw new NotImplementedException();

        }
        public void StartPipeLine()
        {
            throw new NotImplementedException();

        }
        public void CloseSprint()
        {
            throw new NotImplementedException();
        }

        public void ReviewSprint()
        {
            throw new NotImplementedException();
        }
    }
}