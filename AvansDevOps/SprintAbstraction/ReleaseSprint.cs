﻿using AvansDevOps.Pipeline;
using AvansDevOps.SprintDeploymentState;
using AvansDevOps.UserAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.SprintAbstraction
{
    public class ReleaseSprint : Sprint, IDeploymentStateHolder
    {
        public IDeploymentState deploymentState { get; private set; }
        public ReleaseSprint(
            string Name, 
            DateTime StartDate, 
            DateTime EndDate
            ) : base(Name, StartDate, EndDate)
        {
            deploymentState = new NotReadyToDeploy(this);
        }

        public void UpdateDeploymentState(IDeploymentState state) => deploymentState = state;
        public void ApproveDeployment() => deploymentState.ApproveDeployment();
        public bool StartDeployment(DeploymentPipeline pipeline) => deploymentState.StartDeployment(pipeline);
        public void CancelDeployment() => deploymentState.CancelDeployment();
        public void FinishDeployment(bool succeeded) => deploymentState.FinishDeployment(succeeded);

        public void RestartDeployment() => deploymentState.RestartDeployment();
    }
}
