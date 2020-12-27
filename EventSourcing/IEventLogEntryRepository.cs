using System;
using System.Collections.Generic;
using System.Text;

namespace EventSourcing
{
    public interface IEventLogEntryRepository
    {
        EventLogEntry Save(EventLogEntry eventLogEntry);

        IEnumerable<EventLogEntry> GetAll();
    }
}
