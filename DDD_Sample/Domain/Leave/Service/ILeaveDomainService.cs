using Domain.Leave.Entity.ValueObject;
using Domain.Leave.Event;
using Domain.Leave.Repository.Facade;
using Infrastructure.Common.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Leave.Service
{
    public interface ILeaveDomainService
    {
        void CreateLeave(Entity.Leave leave, int leaderMaxLevel, Approver approver);
        void UpdateLeaveInfo(Entity.Leave leave);
        void SubmitApproval(Entity.Leave leave, Approver approver);
        Entity.Leave GetLeaveInfo(string leaveId);
        List<Entity.Leave> QueryLeaveInfosByApplicant(string applicantId);
        List<Entity.Leave> QueryLeaveInfosByApprover(string approverId);
    }
}
