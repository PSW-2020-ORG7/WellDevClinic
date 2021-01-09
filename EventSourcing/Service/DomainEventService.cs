using EventSourcing.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventSourcing.Service
{
    public class DomainEventService : IDomainEventService
    {
        private readonly IDomainEventRepository _domainEventRepository;

        public DomainEventService(IDomainEventRepository domainEventRepository)
        {
            _domainEventRepository = domainEventRepository;
        }

        public DomainEvent Save(DomainEvent domainEvent)
        {
            return _domainEventRepository.Save(domainEvent);
        }

        public IEnumerable<DomainEvent> GetAll(string eventType)
        {
            return _domainEventRepository.GetAll(eventType);
        }


    }
}
