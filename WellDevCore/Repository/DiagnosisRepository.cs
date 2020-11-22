using bolnica;
using bolnica.Model;
using bolnica.Repository;
using bolnica.Repository.CSV;
using Model.PatientSecretary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class DiagnosisRepository : CSVGetterRepository<Diagnosis, long>, IDiagnosisRepository
    {
        private readonly ISymptomRepository _symptomRepository;
        private readonly MyDbContext myDbContext;

        /*public DiagnosisRepository(ISymptomRepository symptomRepository)
        {
            _symptomRepository = symptomRepository;
            MyContextContextFactory mccf = new MyContextContextFactory();
            this.myDbContext = mccf.CreateDbContext(new string[0]);
        }*/

        public DiagnosisRepository(ICSVStream<Diagnosis> stream, ISequencer<long> sequencer, ISymptomRepository symptomRepository)
  : base(stream, sequencer)
        {
            this._symptomRepository = symptomRepository;
            MyContextContextFactory mccf = new MyContextContextFactory();
            this.myDbContext = mccf.CreateDbContext(new string[0]);
        }

        public Diagnosis Get(long id)
            => myDbContext.Diagnosis.FirstOrDefault(diagnosis => diagnosis.Id == id);

        public IEnumerable<Diagnosis> GetAll()
        {
            List<Diagnosis> result = new List<Diagnosis>();
            myDbContext.Diagnosis.ToList().ForEach(diagnosis => result.Add(diagnosis));
            return result;
        }
    }
}
