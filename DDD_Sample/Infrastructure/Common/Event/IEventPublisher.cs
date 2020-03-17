
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Common.Event
{
    public interface IEventPublisher
    {
         void Publish(DomainEvent @event);
    }
}
