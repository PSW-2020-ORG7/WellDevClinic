using SearchAndSchedule_Microservice.Domain;
using SearchAndSchedule_Microservice.Domain.Model;
using SearchAndSchedule_Microservice.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SearchAndSchedule_Microservice.Repository
{
    public class ExaminationRepository : IExaminationRepository
    {
        private readonly MyDbContext _myDbContext;

        public ExaminationRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public void Delete(UpcomingExamination entity)
        {
            _myDbContext.Examination.Remove(entity);
            _myDbContext.SaveChanges();
        }

        public void Edit(UpcomingExamination entity)
        {
            _myDbContext.Examination.Update(entity);
            _myDbContext.SaveChanges();
        }

        public UpcomingExamination Get(long id)
        {
             return _myDbContext.Examination.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<UpcomingExamination> GetAll()
        {
            return _myDbContext.Examination.DefaultIfEmpty().ToList();
        }

        public IEnumerable<UpcomingExamination> GetUpcomingExaminationsByDoctor(Doctor doctor)
        {
            return _myDbContext.Examination.Where(e => e.Doctor.Id == doctor.Id).ToList().DefaultIfEmpty();
        }

        public IEnumerable<UpcomingExamination> GetUpcomingExaminationsByPatient(Patient patient)
        {
            return _myDbContext.Examination.Where(e => e.Patient.Id == patient.Id).ToList().DefaultIfEmpty();
        }

        public UpcomingExamination Save(UpcomingExamination entity)
        {
            var Examination = _myDbContext.Examination.Add(entity);
            _myDbContext.SaveChanges();
            return Examination.Entity;
        }
    }
}
