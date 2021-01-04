using RoomManipulation_Microservice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoomManipulation_Microservice.ApplicationServices.Abstract
{
    public interface IEquipmentAppService : ICRUD<Equipment, long>
    {
        public IEnumerable<Equipment> GetConsumableEquipment();
        public IEnumerable<Equipment> GetInconsumableEquipment();
    }
}
