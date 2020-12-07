using bolnica.Model;
using Model.PatientSecretary;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Repository
{
    public class SymptomRepository : ISymptomRepository
    {
        private readonly MyDbContext myDbContext;

        public SymptomRepository(MyDbContext context)
        {
            myDbContext = context;
        }

        public void Delete(Symptom entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(Symptom entity)
        {
            throw new NotImplementedException();
        }

        public Symptom Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Symptom> GetEager()
        {
            throw new NotImplementedException();
        }

        public Symptom Save(Symptom entity)
        {
            throw new NotImplementedException();
        }
    }
}
