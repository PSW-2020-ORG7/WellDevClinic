using PSW_Pharmacy_Adapter.Model;
using PSW_Pharmacy_Adapter.Repository.Iabstract;
using System.Collections.Generic;
using System.Linq;

namespace PSW_Pharmacy_Adapter.Repository
{
    public class ApiKeyRepository : IApiKeyRepository
    {
        private readonly MyDbContext _MyDbContext;

        public ApiKeyRepository(MyDbContext DbContext)
        {
            _MyDbContext = DbContext;
        }

        public Api Get(string id)
            => _MyDbContext.ApiKeys.FirstOrDefault(api => api.NameOfPharmacy == id);

        public IEnumerable<Api> GetAll()
        {
            List<Api> apis = new List<Api>();
            _MyDbContext.ApiKeys.ToList().ForEach(a => apis.Add(a));
            return apis;
        }

        public bool Exists(string id)
            => Get(id) != null;

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

        public Api Save(Api api)
        {
            Api a = _MyDbContext.ApiKeys.SingleOrDefault(a => a.NameOfPharmacy == api.NameOfPharmacy);
            if (a == null)
            {
                _MyDbContext.ApiKeys.Add(api);
                _MyDbContext.SaveChanges();
                return api;
            }
            return null;
        }

        public Api Update(Api api)
        {
            Api a = _MyDbContext.ApiKeys.SingleOrDefault(a => a.NameOfPharmacy == api.NameOfPharmacy);
            if (a != null)
            {
                _MyDbContext.ApiKeys.Update(api);
                _MyDbContext.SaveChanges();
                return api;
            }
            return null;
        }
    }
}
