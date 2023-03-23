using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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