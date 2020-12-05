using PSW_Pharmacy_Adapter.Model;
using PSW_Pharmacy_Adapter.Repository.Iabstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW_Pharmacy_Adapter.Repository
{
    public class MedicationRepository : IMedicationRepository
    {
        private readonly MyDbContext _MyDbContext;

        public MedicationRepository(MyDbContext DbContext)
        {
            _MyDbContext = DbContext;
        }
        public bool Delete(long id)
        {
            throw new NotImplementedException();
        }

        public bool Exists(long id)
        {
            throw new NotImplementedException();
        }

        public Medication Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Medication> GetAll()
        {
            List<Medication> medications = new List<Medication>();
            _MyDbContext.Medications.ToList().ForEach(a => medications.Add(a));
            return medications;
        }

        public Medication Save(Medication Entity)
        {
            Medication medication = _MyDbContext.Medications.SingleOrDefault(med => med.Id == med.Id);
            if (medication == null)
            {
                _MyDbContext.Medications.Add(medication);
                _MyDbContext.SaveChanges();
                return medication;
            }
            return null;
        }
    }
}
