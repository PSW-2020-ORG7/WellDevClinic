using PSW_Pharmacy_Adapter.Model;
using PSW_Pharmacy_Adapter.Repository;
using PSW_Pharmacy_Adapter.Repository.Iabstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW_Pharmacy_Adapter.Service
{
    public class APIKeyService
    {
        private readonly IAPIKeyRepository KeyRepo;
        public APIKeyService(MyDbContext DbContext)
        {
            KeyRepo = new APIKeyRepository(DbContext);
        }

        public Api GetPharmacy(string id)
            => KeyRepo.Get(id);

        public List<Api> GetAllPharmacies()
            => KeyRepo.GetAll();

        public bool AddPharmacy(Api api)
            => KeyRepo.Save(api);

        public bool DeletePharmacy(string id)
            => KeyRepo.Delete(id);
    }
}
