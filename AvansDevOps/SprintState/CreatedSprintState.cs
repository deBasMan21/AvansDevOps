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
        private Sprint _Sprint;

        public CreatedSprintState(Sprint Sprint)
        {
            this._Sprint = Sprint;
        }

        public void StartSprint()
        {
            _Sprint.UpdateSprintState(new ActiveSprintState(_Sprint));
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