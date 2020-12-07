using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PSW_Pharmacy_Adapter.Model;
using PSW_Pharmacy_Adapter.Repository;
using PSW_Pharmacy_Adapter.Repository.Iabstract;
using PSW_Pharmacy_Adapter.Service.Iabstract;

namespace PSW_Pharmacy_Adapter.Service
{
    public class ApiKeyService : IApiKeyService
    {
        private readonly IApiKeyRepository _KeyRepo;

        public ApiKeyService(IApiKeyRepository apiKeyRepository)
        {
            _KeyRepo = apiKeyRepository;
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
