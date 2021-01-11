using System.Collections.Generic;
using System.Threading.Tasks;
using PSW_Pharmacy_Adapter.Medication_Microservice.Domain.Dto;
using PSW_Pharmacy_Adapter.Medication_Microservice.Domain.Model;

namespace PSW_Pharmacy_Adapter.Medication_Microservice.ApplicationServices.Iabstract
{
    public interface IMedicationService
    {
        public Task<List<Medication>> GetAllHospitalMedications();
        public Task<Medication> GetHospitalMedication(long id);

        public Task<List<MedicationDto>> GetAllPharmacyMedications(string pharmacyName);
        public Task<MedicationDto> GetPharmacyMedication(string pharmacyName, string medName);
        public Task<List<MedicationDto>> GetPharmacyMedications(string pharmacyName, List<string> medicationNames);

        public Task<List<PharmacyMedicationDto>> GetPharmacyByMedicationAsync(Medication med);
        public Task<List<PharmacyMedicationDto>> GetPharmacyByMedicationsAsync(List<Medication> medications);

        public Task<Medication> OrderMedicationAsync(string phName, string medName, int amount);
        public Task<List<Medication>> OrderMedicationsAsync(string phName, List<MedicationOrderDto> orders);
        public Task<List<Medication>> GetUnsyncedMedicationsAsync(string pharmacyName);
    }
}
