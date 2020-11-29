using Model.Director;
using Model.PatientSecretary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bolnica.Model.Dto
{
    public class NotifyDoctorBusinessDay
    {
        public virtual Period shift { get; set; }
        public virtual Room room { get; set; }
        public long Id { get; set; }

        public NotifyDoctorBusinessDay(Period shift, Room room)
        {
            this.shift = shift;
            this.room = room;
        }
        public NotifyDoctorBusinessDay()
        {
            
        }
    }
}
