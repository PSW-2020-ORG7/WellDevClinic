using Examination_Microservice.Domain;
using Examination_Microservice.Domain.Model;
using Examination_Microservice.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Examination_Microservice.Repository
{
    public class ExaminationDetailsRepository : IExaminationDetailsRepository
    {
        private readonly MyDbContext _myDbContext;

        public ExaminationDetailsRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public void Delete(ExaminationDetails entity)
        {
            _myDbContext.ExaminationDetails.Remove(entity);
            _myDbContext.SaveChanges();
        }

        public void Edit(ExaminationDetails entity)
        {
            _myDbContext.ExaminationDetails.Update(entity);
            _myDbContext.SaveChanges();
        }

        public ExaminationDetails Get(long id)
        {
            return _myDbContext.ExaminationDetails.Select(e =>
               new ExaminationDetails()
               {
                   Id = e.Id,
                   Diagnosis = e.Diagnosis,
                   Prescription = e.Prescription,
                   Anamnesis = e.Anamnesis,
                   Therapy =e.Therapy,
                   Sympthom = e.Sympthom

               }
           ).Where(e => e.Id == id).FirstOrDefault();
        }

        public IEnumerable<ExaminationDetails> GetAll()
        {
            return _myDbContext.ExaminationDetails.Select(e =>
               new ExaminationDetails()
               {
                   Id = e.Id,
                   Diagnosis = e.Diagnosis,
                   Prescription = e.Prescription,
                   Anamnesis = e.Anamnesis,
                   Therapy = e.Therapy,
                   Sympthom = e.Sympthom

               }
           ).DefaultIfEmpty().ToList();
        }

        public IEnumerable<ExaminationDetails> GetAllEager()
        {
            return _myDbContext.ExaminationDetails.DefaultIfEmpty().ToList();
        }

        public ExaminationDetails GetEager(long id)
        {
            return _myDbContext.ExaminationDetails.FirstOrDefault(e => e.Id == id);
        }

        public ExaminationDetails Save(ExaminationDetails entity)
        {
            var ExaminationDetails = _myDbContext.ExaminationDetails.Add(entity);
            _myDbContext.SaveChanges();
            return ExaminationDetails.Entity;
        }
    }
}
