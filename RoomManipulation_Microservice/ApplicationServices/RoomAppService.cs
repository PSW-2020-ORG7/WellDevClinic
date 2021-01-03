using RoomManipulation_Microservice.ApplicationServices.Abstract;
using RoomManipulation_Microservice.Domain.Model;
using RoomManipulation_Microservice.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoomManipulation_Microservice.ApplicationServices
{
    public class RoomAppService : IRoomAppService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IRenovationAppService _renovationAppService;

        public RoomAppService(IRoomRepository roomRepository, IRenovationAppService renovationAppService)
        {
            _roomRepository = roomRepository;
            _renovationAppService = renovationAppService;
        }

        public void CheckHospitalizationDurationInRoom()
        {
            throw new NotImplementedException();
        }

        public void Delete(Room entity)
        {
            _renovationAppService.DeleteRenovationByRoom(entity);
            _roomRepository.Delete(entity);
        }

        public void DeleteEquipmentFromRooms(Equipment equipment)
        {
            List<Room> rooms = GetRoomsCointainingEquipment(equipment).ToList();
            foreach(Room r in rooms)
            {
                r.DeleteEquipment(equipment);
                Edit(r);
            }

        }

        public void DeleteRoomsByRoomType(RoomType roomType)
        {
            List<Room> rooms = _roomRepository.GetRoomsByRoomType(roomType);
            foreach(Room r in rooms)
                Delete(r);
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
            return _roomRepository.GetRoomsByEquipment(equipment);
        }

        public List<Room> GetRoomsForHospitalization()
        {
            return _roomRepository.GetRoomsWithFreeSpace();
        }

        public Room Save(Room entity)
        {
            return _roomRepository.Save(entity);
        }
    }
}
