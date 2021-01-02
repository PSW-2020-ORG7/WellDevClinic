using RoomManipulation_Microservice.ApplicationServices.Abstract;
using RoomManipulation_Microservice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoomManipulation_Microservice.ApplicationServices
{
    public class RoomAppService : IRoomAppService
    {
        public void CheckHospitalizationDurationInRoom()
        {
            throw new NotImplementedException();
        }

        public void Delete(Room entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteEquipmentFromRooms(Equipment equipment)
        {
            throw new NotImplementedException();
        }

        public void DeleteRoomsByRoomType(RoomType roomType)
        {
            throw new NotImplementedException();
        }

        public void Edit(Room entity)
        {
            throw new NotImplementedException();
        }

        public Room Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Room> GetAll()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
