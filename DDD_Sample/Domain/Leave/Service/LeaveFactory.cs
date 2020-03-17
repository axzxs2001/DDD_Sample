using Domain.Leave.Entity;
using Domain.Leave.Entity.ValueObject;
using Domain.Leave.Event;
using Domain.Leave.Repository.PO;
using Infrastructure.Common.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Leave.Service
{
    public class LeaveFactory : ILeaveFactory
    {
        public LeavePO CreateLeavePO(Entity.Leave leave)
        {
            var leavePO = new LeavePO()
            {
                Id = leave.Id==null? Guid.NewGuid().ToString():leave.Id,
                ApplicantId = leave.Applicant.PersonId,
                ApplicantName = leave.Applicant.PersonName,
                ApproverId = leave.Approver.PersonId,
                ApproverName = leave.Approver.PersonName,
                StartTime = leave.StartTime,
                EndTime = leave.EndTime,
                Duration = leave.Duration,
                Status = leave.Status,
                //生成请假条时没有当前批认信息
                CurrentApprovalInfo = leave.CurrentApprovalInfo != null ? ApprovalInfoPOFromDO(leave.CurrentApprovalInfo, leave.Applicant.PersonId, leave.Id) : null,
                HistoryApprovalInfoPOList = ApprovalInfoPOListFromDO(leave),
                MaxLeaderLevel = leave.MaxLeaderLevel,
                LeaveType = leave.LeaveType,
                ApplicantType = leave.Applicant.PersonType
            };
            return leavePO;
        }

        public Entity.Leave GetLeave(LeavePO leavePO)
        {
            var leave = new Entity.Leave();
            leave.Id = leavePO.Id;
            var applicant = new Applicant()
            {
                PersonId = leavePO.ApplicantId,
                PersonName = leavePO.ApplicantName
            };
            leave.Applicant = applicant;
            var approver = new Approver()
            {
                PersonId = leavePO.ApproverId,
                PersonName = leavePO.ApproverName
            };
            leave.Approver = approver;
            leave.StartTime = leavePO.StartTime;
            leave.EndTime = leavePO.EndTime;
            leave.Duration = leavePO.Duration;
            leave.Status = leavePO.Status;
            leave.MaxLeaderLevel = leavePO.MaxLeaderLevel;
            if (leavePO.HistoryApprovalInfoPOList?.Count > 0)
            {
                leave.HistoryApprovalInfos = GetApprovalInfos(leavePO.HistoryApprovalInfoPOList);
            }
            return leave;
        }

        public LeaveEventPO CreateLeaveEventPO(LeaveEvent @event)
        {
            var eventPO = new LeaveEventPO()
            {
                LeaveEventType = @event.LeaveEventType,
                Source = @event.Source,
                Timestamp = @event.Timestamp,
                Data = Newtonsoft.Json.JsonConvert.SerializeObject(@event.Data)
            };
            return eventPO;
        }

        private List<ApprovalInfoPO> ApprovalInfoPOListFromDO(Entity.Leave leave)
        {
            var approvalInfoPos = new List<ApprovalInfoPO>();
            foreach (var approvalInfo in leave.HistoryApprovalInfos)
            {
                approvalInfoPos.Add(ApprovalInfoPOFromDO(approvalInfo));
            }
            return approvalInfoPos;
        }

        private ApprovalInfoPO ApprovalInfoPOFromDO(ApprovalInfo approvalInfo, string aplicantId = null, string leaveID = null)
        {
            var approvalInfoPO = new ApprovalInfoPO()
            {
                ApplicantId = aplicantId,
                LeaveId = leaveID,
                ApprovalType = approvalInfo.ApprovalType,
                ApproverId = approvalInfo.Approver.PersonId,
                ApproverLevel = approvalInfo.Approver.Level,
                ApproverName = approvalInfo.Approver.PersonName,
                ApprovalInfoId = string.IsNullOrEmpty(approvalInfo.ApprovalInfoId)?Guid.NewGuid().ToString(): approvalInfo.ApprovalInfoId,
                Msg = approvalInfo.Msg,
                Time = approvalInfo.Time
            };
            return approvalInfoPO;
        }

        private ApprovalInfo ApprovalInfoFromPO(ApprovalInfoPO approvalInfoPO)
        {
            var approvalInfo = new ApprovalInfo();
            approvalInfo.ApprovalInfoId = approvalInfoPO.ApprovalInfoId;
            var approver = new Approver()
            {
                PersonId = approvalInfoPO.ApproverId,
                PersonName = approvalInfoPO.ApproverName,
                Level = approvalInfoPO.ApproverLevel
            };
            approvalInfo.Approver = approver;
            approvalInfo.Msg = approvalInfoPO.Msg;
            approvalInfo.Time = approvalInfoPO.Time;
            return approvalInfo;
        }

        private List<ApprovalInfo> GetApprovalInfos(List<ApprovalInfoPO> approvalInfoPOList)
        {
            var approvalInfos = new List<ApprovalInfo>();
            foreach (var approvalInfo in approvalInfoPOList)
            {
                approvalInfos.Add(ApprovalInfoFromPO(approvalInfo));
            }
            return approvalInfos;
        }
    }
}

