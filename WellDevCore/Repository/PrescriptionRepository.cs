using bolnica.Model;
using Model.PatientSecretary;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Repository
{
     public class PrescriptionRepository : CSVRepository<Prescription, long>, IPrescriptionRepository
    {
        private readonly IDrugRepository _drugRepository;
        private readonly MyDbContext myDbContext;

        /*public PrescriptionRepository(IDrugRepository drugRepository)
        {
            _drugRepository = drugRepository;
            MyContextContextFactory mccf = new MyContextContextFactory();
            this.myDbContext = mccf.CreateDbContext(new string[0]);
        }*/

        public PrescriptionRepository(ICSVStream<Prescription> stream, ISequencer<long> sequencer, IDrugRepository drugRepository)
  : base(stream, sequencer)
        {
            _drugRepository = drugRepository;
            MyContextContextFactory mccf = new MyContextContextFactory();
            this.myDbContext = mccf.CreateDbContext(new string[0]);
        }

        public void Delete(Prescription entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(Prescription entity)
        {
            throw new NotImplementedException();
        }

        public Prescription Get(long id)
            => myDbContext.Prescription.FirstOrDefault(prescription => prescription.Id == id);

        public IEnumerable<Prescription> GetAll()
        {
            List<Prescription> result = new List<Prescription>();
            myDbContext.Prescription.ToList().ForEach(prescription => result.Add(prescription));
            return result;
        }

        public IEnumerable<Prescription> GetAllEager()
        {
            List<Prescription> prescriptions = new List<Prescription>();
            foreach(Prescription pres in GetAll().ToList())
            {
                prescriptions.Add(GetEager(pres.GetId()));
            }
            return prescriptions;
        }

        public Prescription GetEager(long id)
        {
            Prescription prescription = Get(id);
            foreach(Drug drug in prescription.Drug)
            {
                Drug temp = _drugRepository.GetEager(drug.Id);
                drug.Name = temp.Name;
                drug.Amount = temp.Amount;
                drug.Approved = temp.Approved;
            }
            return prescription;
        }

        public Prescription Save(Prescription entity)
        {
            throw new NotImplementedException();
        }
    }
}
