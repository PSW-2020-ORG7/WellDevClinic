using RoomManipulation_Microservice.ApplicationServices.Abstract;
using RoomManipulation_Microservice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoomManipulation_Microservice.Repository.Abstract
{
    public interface IEquipmentRepository : ICRUD<Equipment, long>
    {
        public IEnumerable<Equipment> GetConsumableEquipment();
        public IEnumerable<Equipment> GetInconsumableEquipment();
    }
}
