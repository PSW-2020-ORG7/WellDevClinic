using PSW_Pharmacy_Adapter.Model.Pharmacy;
using System.Collections.Generic;

namespace PSW_Pharmacy_Adapter.Service.Iabstract
{
    public interface ITenderService
    {
        public List<Tender> GetAllTenders();
    }
}
