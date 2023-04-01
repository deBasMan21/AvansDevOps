using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps
{
    public class Repository
    {
        public string BaseUrl { get; private set; }
        public string RepoName { get; private set; }
        private readonly List<Branch> Branches;
        public Repository(string baseUrl, string repoName)
        {
            BaseUrl = baseUrl;
            RepoName = repoName;
            Branches = new List<Branch>();
        }

        public void AddBranch(Branch branch)
        {
            branch.SetRepo(this);
            Branches.Add(branch);
        }

        public void DeleteBranch(Branch branch)
        {
            branch.SetRepo(null);
            Branches.Remove(branch);
        }
    }
}
