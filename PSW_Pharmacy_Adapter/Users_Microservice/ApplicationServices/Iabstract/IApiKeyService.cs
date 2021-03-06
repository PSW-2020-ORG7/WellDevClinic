﻿using System.Collections.Generic;
using PSW_Pharmacy_Adapter.Pharmacy_Microservice.Domain.Model;

namespace PSW_Pharmacy_Adapter.Pharmacy_Microservice.ApplicationServices.Iabstract
{
    public interface IApiKeyService
    {
        public Api GetPharmacy(string id);

        public IEnumerable<Api> GetAllPharmacies();

        public Api AddPharmacy(Api api);

        public bool DeletePharmacy(string id);
    }
}
