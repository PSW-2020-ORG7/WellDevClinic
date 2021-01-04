using System;
using System.Collections.Generic;
using System.Text;

namespace EventSourcing.Service
{
    public interface IDomainEventService
    {
        DomainEvent Save(DomainEvent domainEvent);
        IEnumerable<DomainEvent> GetAll(String eventType);
    }
}
