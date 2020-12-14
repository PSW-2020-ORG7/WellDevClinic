using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW_Pharmacy_Adapter.Dto
{
    public class EPrescriptionDto
    {

        public string PatientName { get; set; }
        public long Jmbg { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public List<MedicineDto> Medicines { get; set; }

        public EPrescriptionDto(){}

        public EPrescriptionDto(string patientName, long jmbg, DateTime startTime, DateTime endTime, List<MedicineDto> medicines)
        {
            PatientName = patientName;
            Jmbg = jmbg;
            StartTime = startTime;
            EndTime = endTime;
            Medicines = medicines;
        }


    }
}
