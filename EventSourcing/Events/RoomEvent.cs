using System;
using System.Collections.Generic;
using System.Text;

namespace EventSourcing.Events
{
    public class RoomEvent:DomainEvent
    {
        public long RoomId { get; private set; }

        public RoomEvent(long roomId) : base()
        {
            this.RoomId = roomId;
        }
    }
}
