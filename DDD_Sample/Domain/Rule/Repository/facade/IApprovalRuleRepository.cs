using Domain.Rule.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Rule.Repository.facade
{
    public interface IApprovalRuleRepository
    {
        int GetLeaderMaxLevel(ApprovalRule rule);
    }
}
