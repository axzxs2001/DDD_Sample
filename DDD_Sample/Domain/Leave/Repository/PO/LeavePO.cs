using Domain.Leave.Entity.ValueObject;
using Domain.Person.Entity;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Text;

namespace Domain.Leave.Repository.PO
{
    public class LeavePO
    {
        public string Id { get; set; }
        public string ApplicantId { get; set; }
        public string ApplicantName { get; set; }
        public PersonType ApplicantType { get; set; }
        public string ApproverId { get; set; }
        public string ApproverName { get; set; }
        public LeaveType LeaveType { get; set; }
        public Status Status { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double Duration { get; set; }
        public int MaxLeaderLevel
        {
            get; set;
        }
        public ApprovalInfoPO CurrentApprovalInfo { get; set; }
        public List<ApprovalInfoPO> HistoryApprovalInfoPOList;
       
    }
}
