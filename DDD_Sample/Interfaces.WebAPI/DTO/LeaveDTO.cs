using Domain.Leave.Entity.ValueObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.WebAPI.DTO
{
    public class LeaveDTO
    {
        public string LeaveId { get; set; }
        public ApplicantDTO ApplicantDTO { get; set; }
        public ApproverDTO ApproverDTO { get; set; }
        public LeaveType LeaveType { get; set; } 
        public int MaxLeaderLevel { get; set; }
        public ApprovalInfoDTO CurrentApprovalInfoDTO { get; set; }
        public List<ApprovalInfoDTO> HistoryApprovalInfoDTOList { get; set; } = new List<ApprovalInfoDTO>();
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public double Duration { get; set; }
        public Status Status { get; set; }

    }
}
