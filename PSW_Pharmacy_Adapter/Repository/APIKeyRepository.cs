using PSW_Pharmacy_Adapter.Model;
using PSW_Pharmacy_Adapter.Repository.Iabstract;
using System.Collections.Generic;
using System.Linq;

namespace PSW_Pharmacy_Adapter.Repository
{
    public class ApiKeyRepository : IApiKeyRepository
    {
        private readonly MyDbContext _dbContext;

        public ApiKeyRepository(MyDbContext DbContext)
        {
            _dbContext = DbContext;
        }

        public Api Get(string id)
            => _dbContext.ApiKeys.FirstOrDefault(api => api.NameOfPharmacy == id);

        public IEnumerable<Api> GetAll()
        {
            List<Api> apis = new List<Api>();
            _dbContext.ApiKeys.ToList().ForEach(a => apis.Add(a));
            return apis;
        }

        public bool Exists(string id)
            => Get(id) != null;

        public bool Delete(string id)
        {
            Api a = _dbContext.ApiKeys.SingleOrDefault(a => a.NameOfPharmacy == id);
            if (a != null)
            {
                _dbContext.ApiKeys.Remove(a);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public Api Save(Api api)
        {
            Api a = _dbContext.ApiKeys.SingleOrDefault(a => a.NameOfPharmacy == api.NameOfPharmacy);
            if (a == null)
            {
                _dbContext.ApiKeys.Add(api);
                _dbContext.SaveChanges();
                return api;
            }
            return null;
        }

        public Api Update(Api api)
        {
            Api a = _dbContext.ApiKeys.SingleOrDefault(a => a.NameOfPharmacy == api.NameOfPharmacy);
            if (a != null)
            {
                _dbContext.ApiKeys.Update(api);
                _dbContext.SaveChanges();
                return api;
            }
            return null;
        }
    }
}
