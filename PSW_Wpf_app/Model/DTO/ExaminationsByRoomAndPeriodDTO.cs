using System;
using System.Collections.Generic;
using System.Text;

namespace PSW_Wpf_app.Model.DTO
{
    public class ExaminationsByRoomAndPeriodDTO
    {
        public Room Room { get; set; }
        public Period Period { get; set; }

        public ExaminationsByRoomAndPeriodDTO(Room room, Period period)
        {
            this.Room = room;
            this.Period = period;
        }
    }
}
