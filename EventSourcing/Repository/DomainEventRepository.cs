using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventSourcing.Repository
{
    public class DomainEventRepository : IDomainEventRepository
    {
        private readonly EventDbContext myDbContext;

        public DomainEventRepository(EventDbContext context)
        {
            myDbContext = context;
        }
        public IEnumerable<DomainEvent> GetAll(String eventType)
        {
            List<DomainEvent> result = new List<DomainEvent>();
            if (eventType.ToLower().Equals("feedbacksubmittedevent"))
                myDbContext.feedbackSubmittedEvents.ToList().ForEach(@event => result.Add(@event));

            return result;
        }

        public DomainEvent Save(DomainEvent domainEvent)
        {
            var @event = (dynamic)domainEvent;
            if (@event is FeedbackSubmittedEvent)
            {
                myDbContext.feedbackSubmittedEvents.Add(@event);
            }

            myDbContext.SaveChanges();
            return domainEvent;
        }
    }
}
