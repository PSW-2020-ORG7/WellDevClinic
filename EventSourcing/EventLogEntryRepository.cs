using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventSourcing
{
    public class EventLogEntryRepository : IEventLogEntryRepository
    {
        private readonly EventDbContext myDbContext;

        public EventLogEntryRepository(EventDbContext context)
        {
            myDbContext = context;
        }

        public IEnumerable<EventLogEntry> GetAll()
        {
            List<EventLogEntry> result = new List<EventLogEntry>();
            myDbContext.Events.ToList().ForEach(@event => result.Add(@event));
            return result;
        }

        public EventLogEntry Save(EventLogEntry eventLogEntry)
        {
            myDbContext.Events.Add(eventLogEntry);
            myDbContext.SaveChanges();
            return eventLogEntry;
        }
    }
}
