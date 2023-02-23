using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.SprintState
{
    public class InDeploymentSprintState : ISprintState
    {
        private Sprint _sprint;

        public InDeploymentSprintState(Sprint Sprint)
        {
            this._sprint = Sprint;
        }

        public void StartSprint()
        {
            throw new NotImplementedException();
        }
        public void FinishSprint()
        {
            throw new NotImplementedException();
        }
        public void CancelSprintDeployment()
        {
            _sprint.UpdateSprintState(new CancelledDeploymentSprintState(_sprint));

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
            _sprint.UpdateSprintState(new ClosedSprintState(_sprint));

        }
    }
}