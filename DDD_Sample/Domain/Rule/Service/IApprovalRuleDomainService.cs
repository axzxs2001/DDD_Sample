using Domain.Rule.Entity;
using Domain.Rule.Repository.facade;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Rule.Service
{
    public interface IApprovalRuleDomainService
    {
        int GetLeaderMaxLevel(string personType, string leaveType, double duration);
    }
}
