using System;
using System.Collections.Generic;
using System.Text;

namespace RoomManipulation_Microservice.Domain.Model
{
    public enum RenovationStatus
    {
        [Description("U toku")]
        Traje,
        [Description("Zavrseno")]
        Zavrseno,
        [Description("Zakazano")]
        Zakazano,
        [Description("Otkazano")]
        Otkazano,

    }
    public class Renovation : IIdentifiable<long>
    {
        public long Id { get; set; }
        public Period Period { get; set; }
        public String Description { get; set; }
        public Room Room { get; set; }
        public RenovationStatus RenovationStatus { get; set; }

        public Renovation(long id, Period period, string description, Room room, RenovationStatus renovationStatus)
        {
            Id = id;
            Period = period;
            Description = description;
            Room = room;
            RenovationStatus = renovationStatus;
        }

        public Renovation()
        {
        }

        public long GetId()
        {
            return Id;
        }

        public void SetId(long id)
        {
            Id = id;
        }
    }
}
