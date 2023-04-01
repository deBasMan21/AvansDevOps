using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvansDevOps.SprintAbstraction;

namespace AvansDevOps.SprintState
{
    public class ClosedSprintState : ISprintState
    {

        public ClosedSprintState(Sprint Sprint) => Sprint.CloseTasks();

        public void FinishSprint() => Console.WriteLine("Sprint has already been closed..");

        public void ReviewSprint(bool approvedDeployement = false) => Console.WriteLine("Sprint has already been closed..");

        public void StartSprint() => Console.WriteLine("Sprint has already been closed..");
    }
}