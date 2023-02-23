using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.SprintState
{
    public class CancelledDeploymentSprintState : ISprintState
    {
        private Sprint _sprint;

        public CancelledDeploymentSprintState(Sprint Sprint)
        {
            this._sprint = Sprint;
        }

        public void StartSprint()
        {

        }
        public void FinishSprint()
        {

        }
        public void CancelSprintDeployment()
        {

        }
        public void StartSprintReview()
        {

        }
        public void StartPipeLine()
        {

        }
        public void CloseSprint()
        {
            _sprint.UpdateSprintState(new ClosedSprintState(_sprint));

        }
    }
}