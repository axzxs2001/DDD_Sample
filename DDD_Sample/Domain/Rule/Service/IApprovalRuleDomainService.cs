using Domain.Leave.Entity.ValueObject;
using Domain.Person.Entity;
using Domain.Rule.Entity;
using Domain.Rule.Repository.facade;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Rule.Service
{
    public interface IApprovalRuleDomainService
    {
        int GetLeaderMaxLevel(PersonType personType, LeaveType leaveType, double duration);
    }
}
