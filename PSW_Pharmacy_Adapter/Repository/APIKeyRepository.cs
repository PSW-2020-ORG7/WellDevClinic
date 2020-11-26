using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bolnica.Model;
using PSW_Pharmacy_Adapter.Model;
using PSW_Pharmacy_Adapter.Repository.Iabstract;

namespace PSW_Pharmacy_Adapter.Repository
{
    public class APIKeyRepository : IAPIKeyRepository
    {
        private readonly MyDbContext myDbContext;

        public Api Get(string id) =>
            Program.Apis.SingleOrDefault(api => api.NameOfHospital == id);

        public List<Api> GetAll() => Program.Apis;

        public bool Save(Api api)
        {
            Api a = Program.Apis.SingleOrDefault(a => a.NameOfHospital == api.NameOfHospital);
            if (a == null)
            {
                Program.Apis.Add(api);
                return true;
            }
            return false;
        }

        public bool Delete(string id)
        {
            Api a = Program.Apis.SingleOrDefault(a => a.NameOfHospital == id);
            if (a != null)
            {
                Program.Apis.Remove(a);
                return true;
            }
            return false;
        }
    }
}
