using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Pipeline
{
    public class TestAction : IActionComponent
    {

        public string TestFramework { get; private set; }
        private bool FinishedTests = false;

        public TestAction(string TestFramework)
        {
            this.TestFramework = TestFramework;
        }

        public bool AcceptVisitor(IActionVisitor visitor) => visitor.VisitTest(this);

        virtual public bool RunTests()
        {
            Console.WriteLine($"Running tests with {TestFramework}");
            FinishedTests = true;
            return true;
        }

        virtual public bool PublishResults()
        {
            if (!FinishedTests)
            {
                Console.WriteLine($"Failed to publish results: tests are not finished");
                return false;
            }

            Console.WriteLine($"Publishing test results");
            return true;
        }

    }
}
