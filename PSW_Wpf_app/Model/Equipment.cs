using System;
using System.Collections.Generic;
using System.Text;

namespace PSW_Wpf_app.Model
{
    public enum EquipmentType
    {
        Consumable,
        Inconsumable,

    }
    public class Equipment
    {
        public long Id { get; set; }
        public String Name { get; set; }
        public int Amount { get; set; }
        public EquipmentType EquipmentType { get; set; }

        public Equipment() { }
    }
}
