using System;
using System.Collections.Generic;
using System.Text;

namespace EventSourcing
{
    public class EventLogEntryService : IEventLogEntryService
    {
        private readonly IEventLogEntryRepository _eventLogRepository;

        public EventLogEntryService(IEventLogEntryRepository eventLogRepository)
        {
            _eventLogRepository = eventLogRepository;
        }

        public IEnumerable<EventLogEntry> GetAll()
        {
            return _eventLogRepository.GetAll();
        }

        public EventLogEntry Save(EventLogEntry eventLogEntry)
        {
            return _eventLogRepository.Save(eventLogEntry);
        }
    }
}
