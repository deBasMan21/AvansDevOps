using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansDevOps.SprintAbstraction;

namespace AvansDevOps.SprintState
{
    public class CreatedSprintState: ISprintState
    {
        private Sprint _sprint;

        public CreatedSprintState(Sprint Sprint)
        {
            this._sprint = Sprint;
        }

        public void FinishSprint()
        {
            throw new NotImplementedException();
        }

        public void ReviewSprint(bool approvedDeployement = false)
        {
            throw new NotImplementedException();
        }

        public void StartSprint()
        {
            _sprint.UpdateSprintState(new ActiveSprintState(_sprint));
        }
    }
}