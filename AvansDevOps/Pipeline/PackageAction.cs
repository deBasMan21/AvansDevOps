using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Pipeline
{
    public class PackageAction: IActionComponent
    {

        public List<String> Dependencies { get; private set; }

        public PackageAction(List<String> Dependencies)
        {
            this.Dependencies = Dependencies;
        }

        public bool AcceptVisitor(IActionVisitor visitor) => visitor.VisitPackage(this);

        public bool InstallDependencies()
        {
            Console.WriteLine("Installing dependencies...");
            foreach (var dependency in Dependencies)
            {
                Console.WriteLine($"Installing {dependency}");
            }
            return true;
        }
    }
}
