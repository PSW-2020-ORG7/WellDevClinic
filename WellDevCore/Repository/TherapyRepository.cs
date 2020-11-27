using bolnica.Model;
using Model.PatientSecretary;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Repository
{
   public class TherapyRepository : ITherapyRepository
    {
        private readonly IDrugRepository _drugRepository;
        private readonly MyDbContext myDbContext;

        public TherapyRepository(IDrugRepository drugRepository, MyDbContext context)
        {
            _drugRepository = drugRepository;
            myDbContext = context;
        }

        /*public TherapyRepository(ICSVStream<Therapy> stream, ISequencer<long> sequencer, IDrugRepository drugRepo)
          : base(stream, sequencer)
        {
            _drugRepository = drugRepo;
            MyContextContextFactory mccf = new MyContextContextFactory();
            this.myDbContext = mccf.CreateDbContext(new string[0]);
        }*/

        public void Delete(Therapy entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(Therapy entity)
        {
            throw new NotImplementedException();
        }

        public Therapy Get(long id)
            => myDbContext.Therapy.FirstOrDefault(therapy => therapy.Id == id);

        public IEnumerable<Therapy> GetEager()
        {
            List<Therapy> result = new List<Therapy>();
            myDbContext.Therapy.ToList().ForEach(therapy => result.Add(therapy));
            return result;
        }

        public IEnumerable<Therapy> GetAllEager()
        {
            List<Therapy> therapy = new List<Therapy>();

            foreach (Therapy t in GetEager().ToList())
            {
                therapy.Add(GetEager(t.GetId()));    
            }
            return therapy; 
        }

        public Therapy GetEager(long id)
        {
            Therapy therapy = Get(id);
            foreach(Drug drug in therapy.Drug)
            {
                Drug temp = _drugRepository.GetEager(drug.Id);
                drug.Name = temp.Name;
                drug.Amount = temp.Amount;
                drug.Approved = temp.Approved;
            }
            return therapy;
        }

        public Therapy Save(Therapy entity)
        {
            throw new NotImplementedException();
        }
    }
}
