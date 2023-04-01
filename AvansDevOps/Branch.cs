using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps
{
    public class Branch
    {
        public string Name { get; private set; }
        public string Url { get; private set; }
        private Repository? repo;

        public Branch(string name, string url)
        {
            Name = name;
            Url = url;
        }

        public void SetRepo(Repository? repo) => this.repo = repo;
    }
}
