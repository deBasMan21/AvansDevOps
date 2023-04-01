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
        public List<Repository> Repository { get; private set; }

        public Project(ProductOwner productOwner)
        {
            ProductOwner = productOwner;
            Sprints = new List<Sprint>();
            ProductBacklog = new Backlog(null);
            Repository = new List<Repository>();
        }

        public void AddSprint(Sprint Sprint)
        {
            Sprint.AssignProductOwner(ProductOwner);
            Sprints.Add(Sprint);
        }
        public void RemoveSprint(Sprint sprint) => Sprints.Remove(sprint);

        public void AddRepository(Repository repository) => Repository.Add(repository);
        public void RemoveRepository(Repository repository) => Repository.Remove(repository);
    }
}
