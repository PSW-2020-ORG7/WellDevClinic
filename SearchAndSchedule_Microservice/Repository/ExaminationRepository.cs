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

        public void Cancel(long id)
        {
            UpcomingExamination examination = _myDbContext.Examination.FirstOrDefault(e => e.Id == id);
            BusinessDay bd = _myDbContext.BussinesDay.FirstOrDefault(e => e.Doctor.Id == examination.Doctor.Id && e.Shift.StartDate.Date == examination.Period.StartDate.Date);
            foreach(Period p in bd.ScheduledPeriods)
            {
                if (p.StartDate == examination.Period.StartDate)
                {
                    bd.ScheduledPeriods.Remove(p);
                    break;
                }
            }
            examination.Canceled = true;
            examination.CanceledDate = DateTime.Now;
            _myDbContext.Examination.Update(examination);
            _myDbContext.SaveChanges();
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

        public List<UpcomingExamination> GetCanceledExaminations()
        {
            return _myDbContext.Examination.Where(e => e.Canceled == true).DefaultIfEmpty().ToList();
        }

        public IEnumerable<UpcomingExamination> GetUpcomingExaminationsByDoctor(Doctor doctor)
        {
            return _myDbContext.Examination.Where(e => e.Doctor.Id == doctor.Id).DefaultIfEmpty().ToList();
        }

        public IEnumerable<UpcomingExamination> GetUpcomingExaminationsByPatient(Patient patient)
        {
            return _myDbContext.Examination.Where(e => e.Patient.Id == patient.Id).DefaultIfEmpty().ToList();
        }

        public UpcomingExamination Save(UpcomingExamination entity)
        {
            Doctor d = _myDbContext.Doctor.FirstOrDefault(e => e.Id == entity.Doctor.Id);
            entity.Doctor = d;
            Patient p = _myDbContext.Patient.FirstOrDefault(e => e.Id == entity.Patient.Id);
            entity.Patient = p;
            BusinessDay bd = _myDbContext.BussinesDay.FirstOrDefault(e => e.Doctor.Id == entity.Doctor.Id && e.Shift.StartDate.Date == entity.Period.StartDate.Date);
            bd.ScheduledPeriods.Add(entity.Period);
            var Examination = _myDbContext.Examination.Add(entity);
            _myDbContext.SaveChanges();
            return Examination.Entity;
        }
    }
}
