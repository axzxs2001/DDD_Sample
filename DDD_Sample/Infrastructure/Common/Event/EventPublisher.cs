
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Common.Event
{
    public class EventPublisher
    {
        public void Publish(DomainEvent @event)
        {
            Console.WriteLine("这里用Queue发布出去：" + @event);
        }
    }
}
