using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.SprintState
{
    public class InSprintReviewState : ISprintState
    {
        private Sprint _sprint;

        public InSprintReviewState(Sprint Sprint)
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
            _sprint.UpdateSprintState(new ClosedSprintState(_sprint));

        }
    }
}