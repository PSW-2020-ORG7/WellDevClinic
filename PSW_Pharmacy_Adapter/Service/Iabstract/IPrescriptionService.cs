using PSW_Pharmacy_Adapter.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PSW_Pharmacy_Adapter.Service.Iabstract
{
    public interface IPrescriptionService
    {
        public Task<List<Prescription>> GetAllPrescriptions();
        public Task<Prescription> GetPrescription(long id);
    }
}
