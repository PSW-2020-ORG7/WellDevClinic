using Model.Director;
using System;
using System.Collections.Generic;
using System.Text;

namespace WellDevCore.Model.Dto
{
    public class EquipmentDTO
    {
        public virtual Equipment Equipment { get; set; }
        public int Amount { get; set; }
        public int Id { get; set; }

        public EquipmentDTO(Equipment equipment, int amount, int id)
        {
            this.Equipment = equipment;
            this.Amount = amount;
            this.Id = id;
        }
        public EquipmentDTO()
        {

        }
    }
}
