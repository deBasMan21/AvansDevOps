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
        public ProductOwner ProductOwner { get; private set; }
        public Backlog ProductBacklog { get; private set; }

        public Project(ProductOwner productOwner)
        {
            this.ProductOwner = productOwner;
            this.Sprints = new List<Sprint>();
            this.ProductBacklog = new Backlog(null);
        }

        public void AddSprint(Sprint Sprint) => Sprints.Add(Sprint);
        public void RemoveSprint(Sprint sprint) => Sprints.Remove(sprint);
    }
}
