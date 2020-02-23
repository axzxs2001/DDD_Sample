using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Leave.Event
{
    public enum LeaveEventType
    {
        CREATE_EVENT,
        AGREE_EVENT,
        REJECT_EVENT,
        APPROVED_EVENT
    }
}
