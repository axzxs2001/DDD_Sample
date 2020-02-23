using Domain.Leave.Entity.ValueObject;
using Domain.Person.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Rule.Repository.PO
{
    public class ApprovalRulePO
    {
        public string Id { get; set; }

        public LeaveType LeaveType { get; set; }

        public PersonType PersonType { get; set; }
        public double Duratione { get; set; }
        public string ApplicantRoleIde { get; set; }
    }
}
