using PSW_Pharmacy_Adapter.Model;
using PSW_Pharmacy_Adapter.Model.Pharmacy;
using System.Collections.Generic;

namespace PSW_Pharmacy_Adapter.Repository.Iabstract
{
    public interface ITenderRepository : IRepository<Tender, long>
    {
        public List<Medication> GetMedications(long id);
    }
}
