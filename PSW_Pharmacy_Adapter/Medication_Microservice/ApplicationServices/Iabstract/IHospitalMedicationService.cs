using PSW_Pharmacy_Adapter.Medication_Microservice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW_Pharmacy_Adapter.Medication_Microservice.ApplicationServices.Iabstract
{
    public interface IHospitalMedicationService
    {
        public Task<List<Medication>> GetAllHospitalMedications();
        public Task<Medication> GetHospitalMedication(long id);
        public Task<Medication> SaveToHospitalAsync(Medication medication);
    }
}
