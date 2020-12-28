using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace EventSourcing
{
    public class EventLogEntry
    {
        private EventLogEntry() { }
        public EventLogEntry(DomainEvent @event)
        {
            EventId = @event.Id;
            CreationTime = @event.TimeStamp;
            EventTypeName = @event.GetType().FullName;
            Content = JsonConvert.SerializeObject(@event);
        }

        public Guid EventId { get; private set; }
        public string EventTypeName { get; private set; }

        [NotMapped]
        public string EventTypeShortName => EventTypeName.Split('.')?.Last();
        [NotMapped]
        public DomainEvent DomainEvent { get; private set; }

        public DateTime CreationTime { get; private set; }
        public string Content { get; private set; }

        public EventLogEntry DeserializeJsonContent(Type type)
        {
            DomainEvent = JsonConvert.DeserializeObject(Content, type) as DomainEvent;
            return this;
        }
    }
}
