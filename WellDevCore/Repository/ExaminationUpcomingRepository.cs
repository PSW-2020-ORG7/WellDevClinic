using bolnica.Model;
using bolnica.Repository;
using Model.PatientSecretary;
using Model.Users;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace bolnica.Repository
{
    public class ExaminationUpcomingRepository : IExaminationUpcomingRepository
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly MyDbContext myDbContext;

        public ExaminationUpcomingRepository( IDoctorRepository doctorRepository, IPatientRepository patientRepository, MyDbContext context)
        {
            _doctorRepository = doctorRepository;
            _patientRepository = patientRepository;
            myDbContext = context;
        }
        public Examination Save(Examination entity)
        {
            throw new NotImplementedException();
        }
        public void Delete(Examination entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(Examination entity)
        {
            Examination examination = GetEager(entity.Id);
            examination.Patient = entity.Patient;
            myDbContext.SaveChanges();
        }

        public Examination Get(long id)
             => myDbContext.Examination.FirstOrDefault(examination => examination.Id == id);
        

        public IEnumerable<Examination> GetEager()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Examination> GetAllEager()
        {
            List<Examination> examinations = new List<Examination>();
            foreach (Examination exam in myDbContext.Examination.ToList())
            {
                if (DateTime.Compare(exam.Period.StartDate.Date, DateTime.Now) >= 0)

                {
                    examinations.Add(exam);
                }
            }
            return examinations;
        }

        public Examination GetEager(long id)
        {
            Examination exam = Get(id);
            exam.Doctor = _doctorRepository.GetEager(exam.Doctor.GetId());
            exam.Patient = _patientRepository.GetEager(exam.Patient.GetId());
            return exam;
        }


    

        public  List<Examination> GetUpcomingExaminationsByUser(User user)
        {  
            try
            {
                Doctor doctor = (Doctor)user;
                List<Examination> examinations = GetAllEager().ToList();
                List<Examination> findExamination = new List<Examination>();
                foreach (Examination examination in examinations)
                {
                    if (examination.Doctor.Id == doctor.Id)
                    {
                        findExamination.Add(examination);
                    }
                }
                return findExamination;
            }catch(Exception e)
            {
                Patient patient = (Patient)user;
                List<Examination> examinations = GetAllEager().ToList();
                List<Examination> findExamination = new List<Examination>();
                foreach (Examination examination in examinations)
                {
                    if (examination.Patient.Id == patient.Id)
                    {
                        findExamination.Add(examination);
                    }
                }
                 return findExamination;
            }
        }


        public Examination Save(long doctorId, Period period, long patientId)
        {
            Doctor doctor = _doctorRepository.Get(doctorId);
            Patient patient = _patientRepository.Get(patientId);
            Examination examination = new Examination(patient,doctor, period);
            myDbContext.Examination.Add(examination);
            myDbContext.SaveChanges();
            return examination;
        }
        public List<Examination> GetAllUpcomingExaminations()
        {
            List<Examination> examinations = new List<Examination>();
            DateTime time = DateTime.Now.AddHours(1);

            foreach (Examination exam in myDbContext.Examination.ToList())
            {
                TimeSpan difference = exam.Period.EndDate.TimeOfDay - exam.Period.StartDate.TimeOfDay;
                if (difference.TotalHours < 1)
                    if (DateTime.Compare(exam.Period.StartDate.Date, DateTime.Now.Date) == 0 && (exam.Period.StartDate.TimeOfDay > DateTime.Now.TimeOfDay) && (exam.Period.StartDate.TimeOfDay < time.TimeOfDay))
                        examinations.Add(exam);
            }
            return examinations;
        }

    }
}