using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Rule.Entity
{
    public class ApprovalRule : IAggregateRoot
    {

        public string PersonType { get; set; }
        public string LeaveType { get; set; }
        public double Duration { get; set; }
        public int MaxLeaderLevel { get; set; }

        public static ApprovalRule GetByLeave(Leave.Entity.Leave leave)
        {
            ApprovalRule rule = new ApprovalRule()
            {
                PersonType = leave.Applicant.PersonType,
                LeaveType = leave.Type.ToString(),
                Duration = leave.Duration
            };
            return rule;
        }
    }
}
