using RoomManipulation_Microservice.ApplicationServices.Abstract;
using RoomManipulation_Microservice.Domain.Model;
using RoomManipulation_Microservice.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoomManipulation_Microservice.ApplicationServices
{
    public class RoomAppService : IRoomAppService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomAppService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public void CheckHospitalizationDurationInRoom()
        {
            throw new NotImplementedException();
        }

        public void Delete(Room entity)
        {
            _roomRepository.Delete(entity);
        }

        public void DeleteEquipmentFromRooms(Equipment equipment)
        {
            List<Room> rooms = _roomRepository.GetRoomsByEquipment(equipment);
            _roomRepository.DeleteByRange(rooms);
        }

        public void DeleteRoomsByRoomType(RoomType roomType)
        {
            throw new NotImplementedException();
        }

        public void Edit(Room entity)
        {
            _roomRepository.Edit(entity);
        }

        public Room Get(long id)
        {
            return _roomRepository.Get(id);
        }

        public IEnumerable<Room> GetAll()
        {
            return _roomRepository.GetAll();
        }

        public IEnumerable<Room> GetRoomsCointainingEquipment(Equipment equipment)
        {
            throw new NotImplementedException();
        }

        public List<Room> GetRoomsForHospitalization()
        {
            throw new NotImplementedException();
        }

        public Room Save(Room entity)
        {
            return _roomRepository.Save(entity);
        }
    }
}
