using System.Collections.Generic;
using PSW_Pharmacy_Adapter.Model;
using PSW_Pharmacy_Adapter.Repository.Iabstract;
using PSW_Pharmacy_Adapter.Service.Iabstract;

namespace PSW_Pharmacy_Adapter.Service
{
    public class ApiKeyService : IApiKeyService
    {
        private readonly IApiKeyRepository _keyRepo;

        public ApiKeyService(IApiKeyRepository apiKeyRepository)
        {
            _keyRepo = apiKeyRepository;
        }

        public Api GetPharmacy(string id)
            => _keyRepo.Get(id);

        public IEnumerable<Api> GetAllPharmacies()
            => _keyRepo.GetAll();

        public Api AddPharmacy(Api api)
            => _keyRepo.Save(api);

        public bool DeletePharmacy(string id)
            => _keyRepo.Delete(id);
    }
}
