using System;
using System.Collections.Generic;
using System.Text;

namespace PSW_Wpf_app.Model
{
    public class EquipmentDTO
    {
        public virtual Equipment Equipment { get; set; }
        public int Amount { get; set; }
        public int Id { get; set; }
    }
}
