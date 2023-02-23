using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.SprintState
{
    public class StartedSprintState : ISprintState
    {
        private Sprint _sprint;

        public StartedSprintState(Sprint Sprint)
        {
            this._sprint = Sprint;
        }

        public void StartSprint()
        {
            throw new NotImplementedException();
        }
        public void FinishSprint()
        {
            _sprint.UpdateSprintState(new FinishedSprintState(_sprint));
        }
        public void CancelSprintDeployment()
        {
            throw new NotImplementedException();
        }
        public void StartSprintReview()
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
    }
}