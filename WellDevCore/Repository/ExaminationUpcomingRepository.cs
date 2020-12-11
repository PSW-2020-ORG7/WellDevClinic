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



    }
}