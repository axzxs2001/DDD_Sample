using Domain.Leave.Repository.PO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Leave.Repository.Facade
{
    public interface ILeaveRepository
    {
        bool Submit(LeavePO leavePO);

        bool Save(LeavePO leavePO);

        bool SaveEvent(LeaveEventPO leaveEventPO);

        LeavePO FindById(string id);

        List<LeavePO> QueryByApplicantId(string applicantId);

        List<LeavePO> QueryByApproverId(string approverId);
    }
}
