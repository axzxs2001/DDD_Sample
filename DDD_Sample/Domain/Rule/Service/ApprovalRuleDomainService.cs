using Domain.Rule.Entity;
using Domain.Rule.Repository.facade;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Rule.Service
{
    public class ApprovalRuleDomainService : IApprovalRuleDomainService
    {
        readonly IApprovalRuleRepository _approvalRuleRepository;
        public ApprovalRuleDomainService(IApprovalRuleRepository approvalRuleRepository)
        {
            _approvalRuleRepository = approvalRuleRepository;
        }

        public int GetLeaderMaxLevel(string personType, string leaveType, double duration)
        {
            var rule = new ApprovalRule()
            {
                PersonType = personType,
                LeaveType = leaveType,
                Duration = duration
            };
            return _approvalRuleRepository.GetLeaderMaxLevel(rule);
        }
    }
}
