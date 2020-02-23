using Domain.Leave.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Leave.Repository.PO
{
    public class LeaveEventPO
    {
        public int Id { get; set; }
        public LeaveEventType LeaveEventType { get; set; }
        public DateTime Timestamp { get; set; }
        public String Source { get; set; }
        public String Data { get; set; }
    }
}
