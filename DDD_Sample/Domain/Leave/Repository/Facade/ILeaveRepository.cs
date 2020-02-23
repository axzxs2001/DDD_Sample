using Domain.Leave.Repository.PO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Leave.Repository.Facade
{
    public interface ILeaveRepository
    {
        void Save(LeavePO leavePO);

        void SaveEvent(LeaveEventPO leaveEventPO);

        LeavePO FindById(string id);

        List<LeavePO> QueryByApplicantId(string applicantId);

        List<LeavePO> QueryByApproverId(string approverId);
    }
}
