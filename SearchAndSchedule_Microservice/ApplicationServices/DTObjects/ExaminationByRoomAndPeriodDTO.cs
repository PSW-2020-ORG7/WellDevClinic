using SearchAndSchedule_Microservice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SearchAndSchedule_Microservice.ApplicationServices.DTObjects
{
    public class ExaminationByRoomAndPeriodDTO
    {
        public Room Room { get; set; }
        public Period Period { get; set; }

        public ExaminationByRoomAndPeriodDTO(Room room, Period period)
        {
            this.Room = room;
            this.Period = period;
        }
    }
}
