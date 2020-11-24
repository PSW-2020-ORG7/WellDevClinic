using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bolnica.Repository;
using PSW_Pharmacy_Adapter.Model;

namespace PSW_Pharmacy_Adapter.Repository.Iabstract
{
    public interface IPharmacyAPIRepository
    {
        public Api Get(String id);
        public List<Api> GetAll();
    }
}
