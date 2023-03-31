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
            DateTime EndDate
            ) : base(Name, StartDate, EndDate)
        {

        }
    }
}
