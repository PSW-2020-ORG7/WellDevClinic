using Examination_Microservice.Domain;
using Examination_Microservice.Domain.Model;
using Examination_Microservice.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Examination_Microservice.Repository
{
    public class DiagnosisRepository : IDiagnosisRepository
    {
        private readonly MyDbContext _myDbContext;

        public DiagnosisRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public void Delete(Diagnosis entity)
        {
            _myDbContext.Diagnosis.Remove(entity);
            _myDbContext.SaveChanges();
        }

        public void Edit(Diagnosis entity)
        {
            _myDbContext.Diagnosis.Update(entity);
            _myDbContext.SaveChanges();
        }

        public Diagnosis Get(long id)
        {
            return _myDbContext.Diagnosis.FirstOrDefault(d => d.Id == id);
        }

        public IEnumerable<Diagnosis> GetAll()
        {
            return _myDbContext.Diagnosis.DefaultIfEmpty().ToList();
        }

        public Diagnosis Save(Diagnosis entity)
        {
            var Diagnosis = _myDbContext.Diagnosis.Add(entity);
            _myDbContext.SaveChanges();
            return Diagnosis.Entity;
        }
    }
}
