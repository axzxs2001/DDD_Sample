using Domain.Leave.Entity.ValueObject;
using Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Leave.Entity
{
    /// <summary>
    /// 假条
    /// </summary>
    public class Leave : IAggregateRoot
    {
        public string Id { get; set; }
        /// <summary>
        /// 申请人
        /// </summary>
        public Applicant Applicant { get; set; }
        /// <summary>
        /// 批准人
        /// </summary>
        public Approver Approver { get; set; }
        /// <summary>
        /// 假条类型
        /// </summary>
        public LeaveType LeaveType { get; set; }
        /// <summary>
        /// 状态 
        /// </summary>
        public Status Status { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndTime { get; set; }
        /// <summary>
        /// 间隔
        /// </summary>
        public double Duration { get; set; }
        /// <summary>
        /// 审批领导的最大级别
        /// </summary>
        public int MaxLeaderLevel { get; set; }
        /// <summary>
        /// 当前审批信息
        /// </summary>
        public ApprovalInfo CurrentApprovalInfo { get; set; }
        /// <summary>
        /// 历史审批信息
        /// </summary>
        public List<ApprovalInfo> HistoryApprovalInfos { get; set; } = new List<ApprovalInfo>();
        /// <summary>
        /// 获取请假小时数
        /// </summary>
        /// <returns></returns>
        public double GetDuration()
        {
            return (EndTime - StartTime).TotalDays;
        }
        /// <summary>
        /// 添加审批信息到历史集合中
        /// </summary>
        /// <param name="approvalInfo"></param>
        /// <returns></returns>
        public Leave AddHistoryApprovalInfo(ApprovalInfo approvalInfo)
        {
            if (null == HistoryApprovalInfos)
            {
                HistoryApprovalInfos = new List<ApprovalInfo>();
            }
            this.HistoryApprovalInfos.Add(approvalInfo);
            return this;
        }
        /// <summary>
        /// 更新案件状态和开始时间
        /// </summary>
        /// <returns></returns>
        public Leave Create()
        {
            this.Status = Status.APPROVING;
            this.StartTime = DateTime.Now;
            return this;
        }
        /// <summary>
        /// 同意审批
        /// </summary>
        /// <param name="nextApprover">下一个审批人</param>
        /// <returns></returns>
        public Leave Agree(Approver nextApprover)
        {
            this.Status = Status.APPROVING;
            this.Approver = nextApprover;
            return this;
        }
        /// <summary>
        /// 拒约审批
        /// </summary>
        /// <param name="approver">批准人</param>
        /// <returns></returns>
        public Leave Reject(Approver approver)
        {
            this.Approver = approver;
            this.Status = Status.REJECTED;
   
            return this;
        }
        /// <summary>
        /// 完成
        /// </summary>
        /// <returns></returns>
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
