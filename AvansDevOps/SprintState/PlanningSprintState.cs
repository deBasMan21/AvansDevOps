using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.SprintState
{
    public class PlanningSprintState: ISprintState
    {
        private Sprint _Sprint;

        public PlanningSprintState(Sprint Sprint)
        {
            this._Sprint = Sprint;
        }

        public void StartSprint()
        {
            _Sprint.UpdateSprintState(new StartedSprintState(_Sprint));
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
            throw new NotImplementedException();
        }
    }
}