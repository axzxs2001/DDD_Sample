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
    public class LeaveFactory: ILeaveFactory
    {
        public LeavePO CreateLeavePO(Leave.Entity.Leave leave)
        {
            var leavePO = new LeavePO()
            {
                Id = Guid.NewGuid().ToString(),
                ApplicantId = leave.Applicant.PersonId,
                ApplicantName = leave.Applicant.PersonName,
                ApproverId = leave.Approver.PersonId,
                ApproverName = leave.Approver.PersonName,
                StartTime = leave.StartTime,
                Status = leave.Status,
                HistoryApprovalInfoPOList = ApprovalInfoPOListFromDO(leave)
            };
            return leavePO;
        }

        public Entity.Leave GetLeave(LeavePO leavePO)
        {
            var leave = new Entity.Leave();
            //todo 这里是值对象，要对Applicant和Approver进行值对象处理
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
            leave.StartTime = leave.StartTime;
            leave.Status = leave.Status;
            leave.HistoryApprovalInfos = GetApprovalInfos(leavePO.HistoryApprovalInfoPOList);
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

        private ApprovalInfoPO ApprovalInfoPOFromDO(ApprovalInfo approvalInfo)
        {
            var approvalInfoPO = new ApprovalInfoPO()
            {
                ApproverId = approvalInfo.Approver.PersonId,
                ApproverLevel = approvalInfo.Approver.Level,
                ApproverName = approvalInfo.Approver.PersonName,
                ApprovalInfoId = approvalInfo.ApprovalInfoId,
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

