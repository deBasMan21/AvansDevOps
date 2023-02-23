using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps
{
    public class Project
    {
        public List<Sprint> Sprints { get; private set; }

        public Project(List<Sprint> Sprints)
        {
            this.Sprints = Sprints;
        }

        public void AddSprint(Sprint Sprint)
        {
            Sprints.Add(Sprint);
        }
        public void RemoveSprint(Sprint sprint)
        {
            Sprints.Remove(sprint);
        }
    }
}
