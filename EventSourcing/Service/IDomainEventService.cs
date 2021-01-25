using EventSourcing.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventSourcing.Service
{
    public interface IDomainEventService
    {
        DomainEvent Save(DomainEvent domainEvent);
        IEnumerable<DomainEvent> GetAll(String eventType);
        long GetMax(String eventType);
        AverageTimeDTO GetStepTime(String eventType);
        long GetMostVisitedRoom();
    }
}
