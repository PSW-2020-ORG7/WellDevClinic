using System.Collections.Generic;
using PSW_Pharmacy_Adapter.Pharmacy_Microservice.ApplicationServices.Iabstract;
using PSW_Pharmacy_Adapter.Pharmacy_Microservice.Domain.Model;
using PSW_Pharmacy_Adapter.Pharmacy_Microservice.Repository.Iabstract;

namespace PSW_Pharmacy_Adapter.Pharmacy_Microservice.ApplicationServices
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
