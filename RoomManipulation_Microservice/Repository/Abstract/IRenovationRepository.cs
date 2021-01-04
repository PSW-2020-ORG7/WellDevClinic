using RoomManipulation_Microservice.ApplicationServices.Abstract;
using RoomManipulation_Microservice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoomManipulation_Microservice.Repository.Abstract
{
    public interface IRenovationRepository : ICRUD<Renovation, long>
    {
        public IEnumerable<Renovation> GetRenovationsByRoomAndPeriod(Room room, Period period);
        public IEnumerable<Renovation> GetRenovationsByRoom(Room room);
        void DeleteRange(List<Renovation> renovations);
    }
}
