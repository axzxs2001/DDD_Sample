using Infrastructure.Common.Event;
using Infrastructure.Util;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft;
using Newtonsoft.Json;

namespace Domain.Leave.Event
{
    public class LeaveEvent : DomainEvent
    {
        public LeaveEventType LeaveEventType { get; set; }

        public static LeaveEvent Create(LeaveEventType eventType, Entity.Leave leave)
        {
            var @event = new LeaveEvent()
            {
                Id = IdGenerator.NextId(),
                LeaveEventType = eventType,
                Timestamp = DateTime.Now,
                Data = JsonConvert.SerializeObject(leave)
            };
            return @event;
        }
    }
}
