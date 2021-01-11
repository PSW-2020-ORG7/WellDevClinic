using System;
using System.Collections.Generic;

namespace PSW_Pharmacy_Adapter.Prescription_Microservice.Domain.Dto
{
    public class EPrescriptionDto
    {

        public string PatientName { get; set; }
        public string Jmbg { get; set; }
        public DateTime StartTime { get; set; }
        public List<MedicationDto> Medicines { get; set; }

        public EPrescriptionDto(){}

        public EPrescriptionDto(string patientName, string jmbg, DateTime startTime, List<MedicationDto> medicines)
        {
            PatientName = patientName;
            Jmbg = jmbg;
            StartTime = startTime;
            Medicines = medicines;
        }


    }
}
