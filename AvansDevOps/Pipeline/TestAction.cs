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

        public void AcceptVisitor(IActionVisitor visitor)
        {
            visitor.VisitTest(this);
        }

        public void RunTests()
        {
            Console.WriteLine($"Running tests with {TestFramework}");
            FinishedTests = true;
        }

        public void PublishResults()
        {
            if (!FinishedTests)
            {
                return;
            }

            Console.WriteLine($"Publishing test results");

        }

    }
}
