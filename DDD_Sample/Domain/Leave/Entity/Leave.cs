using Domain.Leave.Entity.ValueObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Leave.Entity
{
    public class Leave
    {
        public string Id { get; set; }
        public Applicant Applicant { get; set; }
        public Approver Approver { get; set; }
        public LeaveType Type { get; set; }
        public Status Status { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double Duration { get; set; }
        //审批领导的最大级别
        public int LeaderMaxLevel { get; set; }
        public ApprovalInfo CurrentApprovalInfo { get; set; }
        public List<ApprovalInfo> HistoryApprovalInfos { get; set; }

        public double GetDuration()
        {
            return (EndTime - StartTime).TotalMinutes;
        }

        public Leave AddHistoryApprovalInfo(ApprovalInfo approvalInfo)
        {
            if (null == HistoryApprovalInfos)
            {
                HistoryApprovalInfos = new List<ApprovalInfo>();
            }
            this.HistoryApprovalInfos.Add(approvalInfo);
            return this;
        }

        public Leave Create()
        {
            this.Status = Status.APPROVING;
            this.StartTime = DateTime.Now;
            return this;
        }

        public Leave Agree(Approver nextApprover)
        {
            this.Status = Status.APPROVING;
            this.Approver = nextApprover;
            return this;
        }

        public Leave Reject(Approver approver)
        {
            this.Approver = approver;
            this.Status = Status.REJECTED;
            this.Approver = null;
            return this;
        }

        public Leave Finish()
        {
            this.Approver = null;
            this.Status = Status.APPROVED;
            this.EndTime = DateTime.Now;
            this.Duration = (this.EndTime - this.StartTime).TotalSeconds;
            return this;
        }
    }
}
