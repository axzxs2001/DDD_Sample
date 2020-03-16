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
        public string LeaveType { get; set; }
        public ApprovalInfoDTO CurrentApprovalInfoDTO { get; set; }
        public List<ApprovalInfoDTO> HistoryApprovalInfoDTOList { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public double Duration { get; set; }
        public string Status { get; set; }

    }
}
