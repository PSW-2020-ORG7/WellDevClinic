using PSW_Pharmacy_Adapter.Model;
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

        public APIKeyService(IAPIKeyRepository keyRepo)
        {
            _KeyRepo = keyRepo;
        }

        public Api GetPharmacy(string id)
            => _KeyRepo.Get(id);

        public List<Api> GetAllPharmacies()
            => _KeyRepo.GetAll();

        public bool AddPharmacy(Api api)
            => _KeyRepo.Save(api);

        public bool DeletePharmacy(string id)
            => _KeyRepo.Delete(id);
    }
}
