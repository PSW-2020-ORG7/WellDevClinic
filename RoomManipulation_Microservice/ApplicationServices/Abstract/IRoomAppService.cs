using RoomManipulation_Microservice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoomManipulation_Microservice.ApplicationServices.Abstract
{
    public interface IRoomAppService : ICRUD<Room, long>
    {
        public IEnumerable<Room> GetRoomsCointainingEquipment(Equipment equipment);
        public void DeleteRoomsByRoomType(RoomType roomType);
        public void DeleteEquipmentFromRooms(Equipment equipment);
        public List<Room> GetRoomsForHospitalization();
        public void CheckHospitalizationDurationInRoom();
    }
}
