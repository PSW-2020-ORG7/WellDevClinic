using System.Collections.Generic;
using System.Threading.Tasks;
using PSW_Pharmacy_Adapter.Model;

namespace PSW_Pharmacy_Adapter.Service.Iabstract
{
    public interface IMedicationService
    {
        public Task<List<Medication>> GetAllMedication();

        public List<Medication> GetUnsyncedMedicines(string pharmacyName);
    }
}
