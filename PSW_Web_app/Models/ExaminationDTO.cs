using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW_Web_app.Models
{
    public class ExaminationDTO
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public long PatientId { get; set; }
        public long DoctorId { get; set; }

        public ExaminationDTO() { }
    }
}
