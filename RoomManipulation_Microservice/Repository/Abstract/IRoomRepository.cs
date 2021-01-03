using RoomManipulation_Microservice.ApplicationServices.Abstract;
using RoomManipulation_Microservice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoomManipulation_Microservice.Repository.Abstract
{
    public interface IRoomRepository : ICRUD<Room, long>
    {
        public List<Room> GetRoomsByEquipment(Equipment equipment);
        public void DeleteByRange(List<Room> rooms);
    }
}
