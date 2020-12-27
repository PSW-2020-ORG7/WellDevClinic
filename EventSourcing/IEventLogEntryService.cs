using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing
{
    public interface IEventLogEntryService
    {
        EventLogEntry Save(EventLogEntry eventLogEntry);

        IEnumerable<EventLogEntry> GetAll();

    }
}
