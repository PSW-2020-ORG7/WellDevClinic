using System;
using System.Collections.Generic;
using System.Text;

namespace SearchAndSchedule_Microservice.Domain.Model
{
    public class EquipmentStatistic : IIdentifiable<long>
    {
        public long Id { get; set; }
        public int Amount { get; set; }
        public Equipment Equipment { get; set; }

        public EquipmentStatistic() { }
        public EquipmentStatistic(long id, int amount, Equipment equipment)
        {
            Id = id;
            Amount = amount;
            Equipment = equipment;
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
