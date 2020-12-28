using System.Collections.Generic;
using System.Threading.Tasks;
using PSW_Pharmacy_Adapter.Model;

namespace PSW_Pharmacy_Adapter.Service.Iabstract
{
    public interface IMedicationService
    {
        public Task<List<Medication>> GetAllHospitalMedications();
        public Task<Medication> GetHospitalMedication(long id);
        public Task<List<string>> GetPharmacyByMedicineAsync(Medication med);
        public List<Medication> GetUnsyncedMedications(string pharmacyName);
    }
}
