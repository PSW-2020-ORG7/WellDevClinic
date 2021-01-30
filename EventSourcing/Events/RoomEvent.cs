using System;
using System.Collections.Generic;
using System.Text;

namespace EventSourcing.Events
{
    public class RoomEvent : DomainEvent
    {
        public long RoomId { get; private set; }
        public string Username { get; private set; }

        public RoomEvent(long roomId, string username) : base()
        {
            this.RoomId = roomId;
            this.Username = username;
        }
    }
}
