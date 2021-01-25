
using EventSourcing.Events;
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
            if (eventType.ToLower().Equals("newexaminationtimespent"))
                myDbContext.newExaminationTimeSpent.ToList().ForEach(@event => result.Add(@event));
            if (eventType.ToLower().Equals("roomevent"))
                myDbContext.roomEvents.ToList().ForEach(@event => result.Add(@event));

            return result;
        }
        
        public DomainEvent Save(DomainEvent domainEvent)
        {
            var @event = (dynamic)domainEvent;
            if (@event is FeedbackSubmittedEvent)
            {
                myDbContext.feedbackSubmittedEvents.Add(@event);
            }
            if (@event is NewExaminationTimeSpent)
            {
                myDbContext.newExaminationTimeSpent.Add(@event);
            }
            if (@event is RoomEvent)
            {
                myDbContext.roomEvents.Add(@event);
            }

            myDbContext.SaveChanges();
            return domainEvent;
        }

        public long GetMax(string eventType)
        {
            var max = 0;
            if (eventType.ToLower().Equals("newexaminationtimespent"))
            {
                int length = myDbContext.newExaminationTimeSpent.Count();
                /*if(length == 0)
                {
                    return 0;
                }*/
                max = myDbContext.newExaminationTimeSpent.Max(x => Convert.ToInt32(x.ScheduleId));
                max += 1;
            }
            return max;
        }
    }
}
