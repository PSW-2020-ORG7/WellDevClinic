using PSW_Pharmacy_Adapter.Tender_Microservice.Domain.Model;
using System.Collections.Generic;

namespace PSW_Pharmacy_Adapter.Tender_Microservice.Repository.Iabstract
{
    public interface ITenderRepository : IRepository<Tender, long>
    {
        public List<Medication> GetMedications(long id);
        public Tender DeleteTender(long id);
		public Tender UpdateWinner(long idWinner);
    }
}
