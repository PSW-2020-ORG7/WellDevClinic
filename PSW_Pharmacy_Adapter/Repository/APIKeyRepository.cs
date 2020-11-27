using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PSW_Pharmacy_Adapter.Model;
using PSW_Pharmacy_Adapter.Repository.Iabstract;

namespace PSW_Pharmacy_Adapter.Repository
{
    public class APIKeyRepository : IAPIKeyRepository
    {
        private readonly MyDbContext myDbContext;

        public APIKeyRepository(MyDbContext DbContext)
        {
           
            myDbContext = DbContext;
        }

        public Api Get(string id) =>
            myDbContext.ApiKeys.FirstOrDefault(api => api.NameOfHospital == id);

        public List<Api> GetAll()
        {
            List<Api> apis = new List<Api>();
            myDbContext.ApiKeys.ToList().ForEach(a => apis.Add(a));
            return apis;
        }

        public bool Save(Api api)
        {
            Api a = myDbContext.ApiKeys.SingleOrDefault(a => a.NameOfHospital == api.NameOfHospital);
            if (a == null)
            {
                myDbContext.ApiKeys.Add(api);
                myDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Delete(string id)
        {
            Api a = myDbContext.ApiKeys.SingleOrDefault(a => a.NameOfHospital == id);
            if (a != null)
            {
                myDbContext.ApiKeys.Remove(a);
                myDbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
