using RoomManipulation_Microservice.ApplicationServices.Abstract;
using RoomManipulation_Microservice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoomManipulation_Microservice.ApplicationServices
{
    public class RenovationAppService : IRenovationAppService
    {
        public void Delete(Renovation entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteRenovationByRoom(Room room)
        {
            throw new NotImplementedException();
        }

        public void Edit(Renovation entity)
        {
            throw new NotImplementedException();
        }

        public Renovation Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Renovation> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Renovation> GetRenovationsByRoomAndPeriod(Room room, Period period)
        {
            throw new NotImplementedException();
        }

        public Renovation Save(Renovation entity)
        {
            throw new NotImplementedException();
        }
    }
}
