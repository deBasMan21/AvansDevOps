using AvansDevOps.SprintAbstraction;
using AvansDevOps.UserAbstraction;
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
        public ProductOwner productOwner { get; private set; }
        public Backlog projectBacklog { get; private set; }

        public Project(List<Sprint> Sprints, ProductOwner productOwner, Backlog projectBacklog)
        {
            this.Sprints = Sprints;
            this.productOwner = productOwner;
            this.projectBacklog = projectBacklog;
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
