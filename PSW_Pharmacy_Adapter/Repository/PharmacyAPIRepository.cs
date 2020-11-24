using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PSW_Pharmacy_Adapter.Model;
using PSW_Pharmacy_Adapter.Repository.Iabstract;

namespace PSW_Pharmacy_Adapter.Repository
{
    public class PharmacyAPIRepository : IPharmacyAPIRepository
    {
        public Api Get(string id)
        {
            foreach (Api p in Program.Pharmacies)
                if (p.NameOfHospital.Equals(id))
                    return p;
            return null;
        }

        public List<Api> GetAll() => Program.Pharmacies;
    }
}
