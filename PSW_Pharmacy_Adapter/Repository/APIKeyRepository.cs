using PSW_Pharmacy_Adapter.Model;
using PSW_Pharmacy_Adapter.Repository.Iabstract;
using System.Collections.Generic;
using System.Linq;

namespace PSW_Pharmacy_Adapter.Repository
{
    public class APIKeyRepository : IAPIKeyRepository
    {
        private readonly MyDbContext _MyDbContext;

        public APIKeyRepository(MyDbContext DbContext)
        {
            _MyDbContext = DbContext;
        }

        public Api Get(string id)
            => _MyDbContext.ApiKeys.FirstOrDefault(api => api.NameOfPharmacy == id);

        public List<Api> GetAll()
        {
            List<Api> apis = new List<Api>();
            _MyDbContext.ApiKeys.ToList().ForEach(a => apis.Add(a));
            return apis;
        }

        public bool Save(Api api)
        {
            Api a = _MyDbContext.ApiKeys.SingleOrDefault(a => a.NameOfPharmacy == api.NameOfPharmacy);
            if (a == null)
            {
                _MyDbContext.ApiKeys.Add(api);
                _MyDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Delete(string id)
        {
            Api a = _MyDbContext.ApiKeys.SingleOrDefault(a => a.NameOfPharmacy == id);
            if (a != null)
            {
                _MyDbContext.ApiKeys.Remove(a);
                _MyDbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
