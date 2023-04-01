using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Pipeline
{
    public class SourcesAction : IActionComponent
    {

        public string GitUrl { get; private set; }

        public SourcesAction(string GitUrl)
        {
            this.GitUrl = GitUrl;
        }

        public bool AcceptVisitor(IActionVisitor visitor) => visitor.VisitSources(this);

        virtual public bool CloneRepo()
        {
            Console.WriteLine($"Cloning repository from: {GitUrl}");
            return true;
        }
    }
}
