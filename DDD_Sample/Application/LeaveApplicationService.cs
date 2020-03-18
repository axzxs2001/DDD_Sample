using Domain.Leave.Entity.ValueObject;
using Domain.Leave.Service;
using Domain.Person.Service;
using Domain.Rule.Service;
using System;
using System.Collections.Generic;

namespace Application
{
    public class LeaveApplicationService : ILeaveApplicationService
    {

        readonly ILeaveDomainService _leaveDomainService;

        readonly IPersonDomainService _personDomainService;

        readonly IApprovalRuleDomainService _approvalRuleDomainService;
        public LeaveApplicationService(ILeaveDomainService leaveDomainService, IPersonDomainService personDomainService, IApprovalRuleDomainService approvalRuleDomainService)
        {
            _approvalRuleDomainService = approvalRuleDomainService;
            _leaveDomainService = leaveDomainService;
            _personDomainService = personDomainService;
        }


        public void CreateLeaveInfo(Domain.Leave.Entity.Leave leave)
        {

            var maxLeaderLevel = _approvalRuleDomainService.GetLeaderMaxLevel(leave.Applicant.PersonType, leave.LeaveType, leave.Duration);
            var approver = _personDomainService.FindFirstApprover(leave.Applicant.PersonId, maxLeaderLevel);
            //查贸易
            //if（approver == null)
            //{
            //    approver = leave.Approver;
            //}
            _leaveDomainService.CreateLeave(leave, maxLeaderLevel, Approver.FromPerson(approver));
        }

        public void UpdateLeaveInfo(Domain.Leave.Entity.Leave leave)
        {
            _leaveDomainService.UpdateLeaveInfo(leave);
        }

        public void SubmitApproval(Domain.Leave.Entity.Leave leave)
        {
            //获取下一个批准人
            var approver = _personDomainService.FindNextApprover(leave.Approver.PersonId, leave.MaxLeaderLevel);
            //获取批准人级别
            leave.CurrentApprovalInfo.ApproverLevel = _personDomainService.FindById(leave.Approver.PersonId).RoleLevel;
            _leaveDomainService.SubmitApproval(leave, Approver.FromPerson(approver));
        }

        public Domain.Leave.Entity.Leave GetLeaveInfo(string leaveId)
        {
            return _leaveDomainService.GetLeaveInfo(leaveId);
        }

        public List<Domain.Leave.Entity.Leave> QueryLeaveInfosByApplicant(string applicantId)
        {
            return _leaveDomainService.QueryLeaveInfosByApplicant(applicantId);
        }

        public List<Domain.Leave.Entity.Leave> QueryLeaveInfosByApprover(string approverId)
        {
            return _leaveDomainService.QueryLeaveInfosByApprover(approverId);
        }
    }
}
