using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Common.Event
{
    public class DomainEvent
    {
        public string Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string Source { get; set; }
        public string Data { get; set; }
    }
}
