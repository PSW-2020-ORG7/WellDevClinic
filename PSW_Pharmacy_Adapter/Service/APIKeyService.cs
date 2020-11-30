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
        private readonly IAPIKeyRepository _KeyRepo;

        public APIKeyService(MyDbContext dbContext)
        {
            _KeyRepo = new APIKeyRepository(dbContext);
        }

        public Api GetPharmacy(string id)
            => _KeyRepo.Get(id);

        public IEnumerable<Api> GetAllPharmacies()
            => _KeyRepo.GetAll();

        public Api AddPharmacy(Api api)
            => _KeyRepo.Save(api);

        public bool DeletePharmacy(string id)
            => _KeyRepo.Delete(id);
    }
}
