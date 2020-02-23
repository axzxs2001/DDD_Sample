using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Leave.Repository.PO
{
    public class ApprovalInfoPO
    {
        public String ApprovalInfoId { get; set; }
        public String LeaveId { get; set; }
        public String ApplicantId { get; set; }
        public String ApproverId { get; set; }
        public int ApproverLevel { get; set; }
        public String ApproverName { get; set; }
        public String Msg { get; set; }
        public double Time { get; set; }
    }
}
