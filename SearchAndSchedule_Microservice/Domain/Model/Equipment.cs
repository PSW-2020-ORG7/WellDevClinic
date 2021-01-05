using System;
using System.Collections.Generic;
using System.Text;

namespace SearchAndSchedule_Microservice.Domain.Model
{
    public enum EquipmentType
    {
        Consumable,
        Inconsumable,

    }
    public class Equipment : IIdentifiable<long>
    {
        public long Id { get; set; }
        public String Name { get; set; }
        public int Amount { get; set; }
        public EquipmentType EquipmentType { get; set; }

        public Equipment() { }

        public Equipment(long id, string name, int amount, EquipmentType equipmentType)
        {
            Id = id;
            Name = name;
            Amount = amount;
            EquipmentType = equipmentType;
        }

        public long GetId()
        {
            return Id;
        }

        public void SetId(long id)
        {
            Id = id;
        }
    }
}
