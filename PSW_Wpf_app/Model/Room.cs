using System;
using System.Collections.Generic;
using System.Text;

namespace PSW_Wpf_app.Model
{
    public class Room
    {
        public long Id { get; set; }
        public virtual List<EquipmentStatistic> EquipmentStatistic { get; set; }
        public String RoomCode { get; set; }
        public virtual RoomType RoomType { get; set; }
        public int MaxNumberOfPatientsForHospitalization { get; set; }
        public int CurrentNumberOfPatients { get; set; }
        //public virtual List<EquipmentDTO> Equipment_inventory { get; set; }

    }
}
