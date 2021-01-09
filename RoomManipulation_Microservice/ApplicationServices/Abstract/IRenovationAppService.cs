using RoomManipulation_Microservice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoomManipulation_Microservice.ApplicationServices.Abstract
{
    public interface IRenovationAppService : ICRUD<Renovation, long>
    {
        public IEnumerable<Renovation> GetRenovationsByRoomAndPeriod(Room room, Period period);
        public void DeleteRenovationByRoom(Room room);
    }
}
