using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansDevOps.SprintState;

namespace AvansDevOps
{
    public class Sprint
    {
        public String Name { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public Boolean IsRelease { get; private set; }

        public User ProductOwner { get; private set; }
        public User ScrumMaster { get; private set; }
        public List<User> Developers { get; private set; }

        private ISprintState currentState;


        public Sprint(String Name, DateTime StartDate, DateTime EndDate, Boolean IsRelease, User ProductOwner, User ScrumMaster, List<User> Developers)
        {
            this.Name = Name;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.IsRelease = IsRelease;
            this.ProductOwner = ProductOwner;
            this.ScrumMaster = ScrumMaster;
            this.Developers = Developers; 
            this.currentState = new PlanningSprintState(this);
        }

        public void AddDeveloper(User Developer)
        {
            Developers.Add(Developer);
        }
        public void RemoveDeveloper(User Developer)
        {
            Developers.Remove(Developer);
        }

        public void UpdateSprintState(ISprintState currentState)
        {
            this.currentState = currentState;
        }
        public void StartSprint()
        {
            currentState.StartSprint();
        }
        public void FinishSprint()
        {
            currentState.FinishSprint();
        }
        public void CancelSprintDeployment()
        {
            currentState.CancelSprintDeployment();
        }
        public void StartSprintReview()
        {
            currentState.StartSprint();
        }
        public void StartPipeLine()
        {
            currentState.StartPipeLine();
        }
        public void CloseSprint()
        {
            currentState.CloseSprint();

        }
    }
}
