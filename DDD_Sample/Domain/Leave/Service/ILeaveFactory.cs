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
    public interface ILeaveFactory
    {
        LeavePO CreateLeavePO(Entity.Leave leave);

        Entity.Leave GetLeave(LeavePO leavePO);

        LeaveEventPO CreateLeaveEventPO(LeaveEvent @event);
    }
}

