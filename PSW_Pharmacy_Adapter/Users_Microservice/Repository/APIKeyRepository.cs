using PSW_Pharmacy_Adapter.Pharmacy_Microservice.Domain.Model;
using PSW_Pharmacy_Adapter.Pharmacy_Microservice.Repository.Iabstract;
using System.Collections.Generic;
using System.Linq;

namespace PSW_Pharmacy_Adapter.Pharmacy_Microservice.Repository
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

        public Api Save(Api entity)
        {
            Api a = _dbContext.ApiKeys.SingleOrDefault(a => a.NameOfPharmacy == entity.NameOfPharmacy);
            if (a == null)
            {
                _dbContext.ApiKeys.Add(entity);
                _dbContext.SaveChanges();
                return entity;
            }
            return null;
        }

        public Api Update(Api entity)
        {
            Api a = _dbContext.ApiKeys.SingleOrDefault(a => a.NameOfPharmacy == entity.NameOfPharmacy);
            if (a != null)
            {
                _dbContext.ApiKeys.Update(entity);
                _dbContext.SaveChanges();
                return entity;
            }
            return null;
        }
    }
}
