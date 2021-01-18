using System;
using System.Collections.Generic;
using System.Text;

namespace PSW_Wpf_app.Model
{
    public class EquipmentStatistic
    {
        public long Id { get; set; }
        public int Amount { get; set; }
        public virtual Equipment Equipment { get; set; }

        public EquipmentStatistic() { }
    }
}
