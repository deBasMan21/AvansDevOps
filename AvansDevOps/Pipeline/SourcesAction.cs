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

        public SourcesAction(string GityUrl)
        {
            this.GitUrl = GityUrl;
        }

        public void AcceptVisitor(IActionVisitor visitor)
        {
            visitor.VisitSources(this);
        }

        public void CloneRepo()
        {
            Console.WriteLine($"Cloning repository from: {GitUrl}");
        }
    }
}
