using Examination_Microservice.Domain;
using Examination_Microservice.Domain.Model;
using Examination_Microservice.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Examination_Microservice.Repository
{
    public class PatientFileRepository : IPatientFileRepository
    {
        private readonly MyDbContext _myDbContext;

        public PatientFileRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public void Delete(PatientFile entity)
        {
            _myDbContext.PatientFile.Remove(entity);
            _myDbContext.SaveChanges();
        }

        public void Edit(PatientFile entity)
        {
            _myDbContext.PatientFile.Update(entity);
            _myDbContext.SaveChanges();
        }

        public PatientFile Get(long id)
        {
            return _myDbContext.PatientFile.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<PatientFile> GetAll()
        {
            return _myDbContext.PatientFile.DefaultIfEmpty().ToList();
        }

        public PatientFile Save(PatientFile entity)
        {
            var PatientFile = _myDbContext.PatientFile.Add(entity);
            _myDbContext.SaveChanges();
            return PatientFile.Entity;
        }
    }
}
