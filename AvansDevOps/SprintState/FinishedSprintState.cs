using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.SprintState
{
    public class FinishedSprintState : ISprintState
    {
        private Sprint _sprint;

        public FinishedSprintState(Sprint Sprint)
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
            _sprint.UpdateSprintState(new InSprintReviewState(_sprint));

        }
        public void StartPipeLine()
        {
            _sprint.UpdateSprintState(new CancelledDeploymentSprintState(_sprint));

        }
        public void CloseSprint()
        {
            throw new NotImplementedException();
        }
    }
}