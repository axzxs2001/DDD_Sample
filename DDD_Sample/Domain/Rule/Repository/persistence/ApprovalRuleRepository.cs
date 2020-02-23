using Domain.Rule.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Rule.Repository.persistence
{
    public class ApprovalRuleRepository
    {
        public int GetLeaderMaxLevel(ApprovalRule rule)
        {
            var personType = rule.PersonType;
            var leaveType = rule.LeaveType;
            // rule.Duration
            //todo 这里数据查询获得
            rule = new ApprovalRule();
            return rule.MaxLeaderLevel;
        }
    }
}
