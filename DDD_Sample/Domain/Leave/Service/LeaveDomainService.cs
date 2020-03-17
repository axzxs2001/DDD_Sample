using Domain.Leave.Entity.ValueObject;
using Domain.Leave.Event;
using Domain.Leave.Repository.Facade;
using Infrastructure.Common.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Leave.Service
{
    public class LeaveDomainService : ILeaveDomainService
    {
        readonly IEventPublisher _eventPublisher;

        readonly ILeaveRepository _leaveRepository;

        readonly ILeaveFactory _leaveFactory;

        public LeaveDomainService(IEventPublisher eventPublisher, ILeaveRepository leaveRepository, ILeaveFactory leaveFactory)
        {
            _eventPublisher = eventPublisher;
            _leaveRepository = leaveRepository;
            _leaveFactory = leaveFactory;
        }


        public void CreateLeave(Entity.Leave leave, int maxLeaderLevel, Approver approver)
        {
            leave.MaxLeaderLevel = maxLeaderLevel;
            leave.Approver = approver;
            leave.Create();
            _leaveRepository.Save(_leaveFactory.CreateLeavePO(leave));
            var @event = LeaveEvent.Create(LeaveEventType.CREATE_EVENT, leave);
            _leaveRepository.SaveEvent(_leaveFactory.CreateLeaveEventPO(@event));
            _eventPublisher.Publish(@event);
        }


        public void UpdateLeaveInfo(Entity.Leave leave)
        {
            var po = _leaveRepository.FindById(leave.Id);
            if (null == po)
            {
                throw new Exception("leave does not exist");
            }
            _leaveRepository.Save(_leaveFactory.CreateLeavePO(leave));
        }


        public void SubmitApproval(Entity.Leave leave, Approver approver)
        {
            LeaveEvent @event;
            if (ApprovalType.REJECT == leave.CurrentApprovalInfo.ApprovalType)
            {
                //reject, then the leave is finished with REJECTED status
                leave.Reject(approver);
                @event = LeaveEvent.Create(LeaveEventType.REJECT_EVENT, leave);
            }
            else
            {
                if (approver != null)
                {
                    //agree and has next approver
                    leave.Agree(approver);
                    @event = LeaveEvent.Create(LeaveEventType.AGREE_EVENT, leave);
                }
                else
                {
                    //agree and hasn't next approver, then the leave is finished with APPROVED status
                    leave.Finish();
                    @event = LeaveEvent.Create(LeaveEventType.APPROVED_EVENT, leave);
                }
            }
            leave.AddHistoryApprovalInfo(leave.CurrentApprovalInfo);
            _leaveRepository.Submit(_leaveFactory.CreateLeavePO(leave));
            _leaveRepository.SaveEvent(_leaveFactory.CreateLeaveEventPO(@event));
            _eventPublisher.Publish(@event);
        }

        public Entity.Leave GetLeaveInfo(string leaveId)
        {
            var leavePO = _leaveRepository.FindById(leaveId);
            return _leaveFactory.GetLeave(leavePO);
        }

        public List<Entity.Leave> QueryLeaveInfosByApplicant(string applicantId)
        {
            var leaves = new List<Entity.Leave>();
            var leavePOList = _leaveRepository.QueryByApplicantId(applicantId);
            foreach (var leavePO in leavePOList)
            {
                leaves.Add(_leaveFactory.GetLeave(leavePO));
            }
            return leaves;
        }

        public List<Entity.Leave> QueryLeaveInfosByApprover(string approverId)
        {
            var leaves = new List<Entity.Leave>();
            var leavePOList = _leaveRepository.QueryByApproverId(approverId);
            foreach (var leavePO in leavePOList)
            {
                leaves.Add(_leaveFactory.GetLeave(leavePO));
            }
            return leaves;
        }
    }
}
