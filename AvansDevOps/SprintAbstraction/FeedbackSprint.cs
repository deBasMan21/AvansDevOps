using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansDevOps.UserAbstraction;

namespace AvansDevOps.SprintAbstraction
{
    public class FeedbackSprint : Sprint
    {
        public FeedbackSprint(
            string Name, 
            DateTime StartDate, 
            DateTime EndDate, 
            LeadDeveloper productOwner, 
            ScrumMaster scrumMaster, 
            List<Developer> developers
            ) : base(Name, StartDate, EndDate, productOwner, scrumMaster, developers)
        {
        }

        public override void StartClosedSprintAction() { }
    }
}
