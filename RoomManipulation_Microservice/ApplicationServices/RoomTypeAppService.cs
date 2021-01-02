using RoomManipulation_Microservice.ApplicationServices.Abstract;
using RoomManipulation_Microservice.Domain.Model;
using RoomManipulation_Microservice.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoomManipulation_Microservice.ApplicationServices
{
    public class RoomTypeAppService : IRoomTypeAppService
    {
        private readonly IRoomTypeRepository _roomTypeRepository;

        public RoomTypeAppService(IRoomTypeRepository roomTypeRepository)
        {
            _roomTypeRepository = roomTypeRepository;
        }

        public void Delete(RoomType entity)
        {
            _roomTypeRepository.Delete(entity);
        }

        public void Edit(RoomType entity)
        {
            _roomTypeRepository.Edit(entity);
        }

        public RoomType Get(long id)
        {
            return _roomTypeRepository.Get(id);
        }

        public IEnumerable<RoomType> GetAll()
        {
            return _roomTypeRepository.GetAll();
        }

        public RoomType Save(RoomType entity)
        {
            return _roomTypeRepository.Save(enum);
        }
    }
}
