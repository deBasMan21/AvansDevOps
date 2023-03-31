using AvansDevOps.UserAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps
{
    public class Activity
    {
       public string Task { get;  private set; }
        public bool IsFinished { get; private set; } = false;
        public Developer? Developer { get; private set; }

        public Activity(string Task)
        {
            this.Task = Task;
        }

        public void AssignDeveloper(Developer dev) => Developer = dev;

        public void FinishTask() {
            IsFinished = true;
        }
    }
}
