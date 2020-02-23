using Domain.Leave.Repository.PO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Leave.Repository.Persistence
{
    public class LeaveRepository : ILeaveRepository
    {


        readonly LeaveDao leaveDao;
        ApprovalInfoDao approvalInfoDao;
        LeaveEventDao leaveEventDao;

        public void Save(LeavePO leavePO)
        {

        }

        public void SaveEvent(LeaveEventPO leaveEventPO)
        {

        }


        public LeavePO FindById(string id)
        {
            return new LeavePO() { Id = id };
        }


        public List<LeavePO> QueryByApplicantId(string applicantId)
        {
            var leavePOList = new List<LeavePO>();
            return leavePOList;
        }

        public List<LeavePO> QueryByApproverId(string approverId)
        {
            varleavePOList = new List<LeavePO>();
            return leavePOList;
        }

    }
}
