﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Pipeline
{
    public class DeploymentPipeline : ActionGroupComposite
    {
        override public bool AcceptVisitor(IActionVisitor visitor) => visitor.VisitPipeline(this) && base.AcceptVisitor(visitor);

        virtual public bool StartPipeline() {
            Console.WriteLine("-- Run pipeline --");
            return true;
        }

    }
}
