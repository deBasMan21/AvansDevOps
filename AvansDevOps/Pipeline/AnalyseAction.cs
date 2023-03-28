﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Pipeline
{
    public class AnalyseAction : IActionComponent
    {

        public string AnalyseTool { get; private set; }

        public AnalyseAction(string AnalyseTool)
        {
            this.AnalyseTool = AnalyseTool;
        }

        public void AcceptVisitor(IActionVisitor visitor)
        {
            visitor.VisitAnalyse(this);
        }

        public void RunAnalysis()
        {
            Console.WriteLine($"{AnalyseTool}: Performing code analysis");
        }
    }
}
