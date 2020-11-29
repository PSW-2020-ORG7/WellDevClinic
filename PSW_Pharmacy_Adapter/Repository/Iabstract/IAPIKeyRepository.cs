using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PSW_Pharmacy_Adapter.Model;

namespace PSW_Pharmacy_Adapter.Repository.Iabstract
{
    public interface IAPIKeyRepository
    {
        public Api Get(String id);
        public List<Api> GetAll();
        public bool Save(Api api);
        public bool Delete(string id);
    }
}
