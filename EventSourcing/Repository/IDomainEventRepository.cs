using System;
using System.Collections.Generic;
using System.Text;

namespace EventSourcing.Repository
{
    public interface IDomainEventRepository
    {
        DomainEvent Save(DomainEvent domainEvent);
        IEnumerable<DomainEvent> GetAll(String eventType);
        long GetMax(String eventType);
    }
}
