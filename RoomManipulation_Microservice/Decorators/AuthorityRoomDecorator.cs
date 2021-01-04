using RoomManipulation_Microservice.ApplicationServices.Abstract;
using RoomManipulation_Microservice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoomManipulation_Microservice.Decorators
{
    public  class AuthorityRoomDecorator : IRoomAppService
    {
        private readonly IRoomAppService _roomAppService;
        public String Role { get; set; }
        private readonly Dictionary<String, List<String>> AuthorizedUsers;

        public AuthorityRoomDecorator(IRoomAppService roomAppService)
        {
            _roomAppService = roomAppService;
            AuthorizedUsers = new Dictionary<string, List<string>>
            {
                ["AddEquipment"] = new List<string>() { "Director" },
                ["CheckHospitalizationDurationInRoom"] = new List<string>() { "Director", "Doctor" },
                ["CheckRoomCodeUnique"] = new List<string>() { "Director" },
                ["Delete"] = new List<string>() { "Director" },
                ["Edit"] = new List<string>() { "Director" },
                ["GetRoomsCointainingEquipment"] = new List<string>() { "Director" },
                ["GetRoomsForHospitalization"] = new List<string>() { "Doctor" },
                ["Save"] = new List<string>() { "Director" },
                ["Get"] = new List<string>() { "Director", "Doctor", "Secretary" },
                ["GetAll"] = new List<string>() { "Director", "Doctor", "Secretary" },
                ["DeleteRoomsByRoomType"] = new List<string>() { "Director" },
                ["DeleteEquipmentFromRooms"] = new List<string>() { "Director" }
            };

        }

        public void CheckHospitalizationDurationInRoom()
        {
            if (AuthorizedUsers["CheckHospitalizationDurationInRoom"].SingleOrDefault(any => any.Equals(Role)) != null)
                _roomAppService.CheckHospitalizationDurationInRoom();
        }

        public void Delete(Room entity)
        {
            if (AuthorizedUsers["Delete"].SingleOrDefault(any => any.Equals(Role)) != null)
                _roomAppService.Delete(entity);
        }

        public void Edit(Room entity)
        {
            if (AuthorizedUsers["Edit"].SingleOrDefault(any => any.Equals(Role)) != null)
                _roomAppService.Edit(entity);
        }

        public Room Get(long id)
        {
            if (AuthorizedUsers["Get"].SingleOrDefault(any => any.Equals(Role)) != null)
                return _roomAppService.Get(id);
            return null;
        }

        public IEnumerable<Room> GetAll()
        {
            if (AuthorizedUsers["GetAll"].SingleOrDefault(any => any.Equals(Role)) != null)
                return _roomAppService.GetAll();
            return null;
        }

        public IEnumerable<Room> GetRoomsCointainingEquipment(Equipment equipment)
        {
            if (AuthorizedUsers["GetRoomsCointainingEquipment"].SingleOrDefault(any => any.Equals(Role)) != null)
                return _roomAppService.GetRoomsCointainingEquipment(equipment);
            return null;
        }

        public List<Room> GetRoomsForHospitalization()
        {
            if (AuthorizedUsers["GetRoomsForHospitalization"].SingleOrDefault(any => any.Equals(Role)) != null)
                return _roomAppService.GetRoomsForHospitalization();
            return null;
        }

        public Room Save(Room entity)
        {
            if (AuthorizedUsers["Save"].SingleOrDefault(any => any.Equals(Role)) != null)
                return _roomAppService.Save(entity);
            return null;
        }

        public void DeleteRoomsByRoomType(RoomType roomType)
        {
            if (AuthorizedUsers["DeleteRoomsByRoomType"].SingleOrDefault(any => any.Equals(Role)) != null)
                _roomAppService.DeleteRoomsByRoomType(roomType);
        
        }

        public void DeleteEquipmentFromRooms(Equipment equipment)
        {
            if (AuthorizedUsers["DeleteEquipmentFromRooms"].SingleOrDefault(any => any.Equals(Role)) != null)
                _roomAppService.DeleteEquipmentFromRooms(equipment);
        }
    }
}
