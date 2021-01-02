using RoomManipulation_Microservice.ApplicationServices.Abstract;
using RoomManipulation_Microservice.Domain.Model;
using RoomManipulation_Microservice.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoomManipulation_Microservice.ApplicationServices
{
    public class RenovationAppService : IRenovationAppService
    {
        private readonly IRenovationRepository _renovationRepository;

        public RenovationAppService(IRenovationRepository renovationRepository)
        {
            _renovationRepository = renovationRepository;
        }

        public void Delete(Renovation entity)
        {
            _renovationRepository.Delete(entity);
        }

        public void DeleteRenovationByRoom(Room room)
        {
            throw new NotImplementedException();
        }

        public void Edit(Renovation entity)
        {
            _renovationRepository.Edit(entity);
        }

        public Renovation Get(long id)
        {
            return _renovationRepository.Get(id);
        }

        public IEnumerable<Renovation> GetAll()
        {
            return _renovationRepository.GetAll();
        }

        public IEnumerable<Renovation> GetRenovationsByRoomAndPeriod(Room room, Period period)
        {
            return _renovationRepository.GetRenovationsByRoomAndPeriod(room, period);
        }

        public Renovation Save(Renovation entity)
        {
            return _renovationRepository.Save(entity);
        }
    }
}
