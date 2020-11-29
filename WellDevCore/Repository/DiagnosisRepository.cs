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
    public class DiagnosisRepository : IDiagnosisRepository
    {
        private readonly ISymptomRepository _symptomRepository;
        private readonly MyDbContext myDbContext;

        public DiagnosisRepository(ISymptomRepository symptomRepository, MyDbContext context)
        {
            _symptomRepository = symptomRepository;
            myDbContext = context;
        }

     
        public Diagnosis Get(long id)
            => myDbContext.Diagnosis.FirstOrDefault(diagnosis => diagnosis.Id == id);

        public IEnumerable<Diagnosis> GetEager()
        {
            List<Diagnosis> result = new List<Diagnosis>();
            myDbContext.Diagnosis.ToList().ForEach(diagnosis => result.Add(diagnosis));
            return result;
        }
    }
}
