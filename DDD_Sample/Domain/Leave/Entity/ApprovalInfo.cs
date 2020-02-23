using Domain.Leave.Entity.ValueObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Leave.Entity
{
    public class ApprovalInfo
    {
        public string ApprovalInfoId { get; set; }
        public Approver Approver { get; set; }
        public ApprovalType ApprovalType { get; set; }
        public string Msg { get; set; }
        public double Time { get; set; }
    }
}
