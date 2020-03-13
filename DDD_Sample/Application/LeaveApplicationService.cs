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

        /**
         * 创建一个请假申请并为审批人生成任务
         * @param leave
         */
        public void CreateLeaveInfo(Domain.Leave.Entity.Leave leave)
        {
            //get approval leader max level by rule
            var leaderMaxLevel = _approvalRuleDomainService.GetLeaderMaxLevel(leave.Applicant.PersonType, leave.Type.ToString(), leave.Duration);
            //find next approver
            var approver = _personDomainService.FindFirstApprover(leave.Applicant.PersonId, leaderMaxLevel);
            _leaveDomainService.CreateLeave(leave, leaderMaxLevel, Approver.FromPerson(approver));
        }

        /**
         * 更新请假单基本信息
         * @param leave
         */
        public void UpdateLeaveInfo(Domain.Leave.Entity.Leave leave)
        {
            _leaveDomainService.UpdateLeaveInfo(leave);
        }

        /**
         * 提交审批，更新请假单信息
         * @param leave
         */
        public void SubmitApproval(Domain.Leave.Entity.Leave leave)
        {
            //find next approver
            var approver = _personDomainService.FindNextApprover(leave.Approver.PersonId, leave.LeaderMaxLevel);
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
