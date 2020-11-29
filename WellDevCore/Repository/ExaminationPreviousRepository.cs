using bolnica;
using bolnica.Model;
using bolnica.Repository;
using Model.PatientSecretary;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using bolnica.Model.Adapters;
using bolnica.Model.dtos;
using Model.Dto;

namespace Repository
{
    public class ExaminationPreviousRepository : IExaminationPreviousRepository
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IDiagnosisRepository _diagnosisRepository;
        private readonly IPrescriptionRepository _prescriptionRepository;
        private readonly ITherapyRepository _therapyRepository;
        private readonly IReferralRepository _referralRepository;
        private readonly MyDbContext myDbContext;

        public ExaminationPreviousRepository(IDoctorRepository doctorRepository,  IDiagnosisRepository diagnosisRepository, IPrescriptionRepository prescriptionRepository, ITherapyRepository therapyRepository, IReferralRepository referralRepository, MyDbContext context)
        {
            _doctorRepository = doctorRepository;
            _diagnosisRepository = diagnosisRepository;
            _prescriptionRepository = prescriptionRepository;
            _therapyRepository = therapyRepository;
            _referralRepository = referralRepository;
            myDbContext = context;
        }

        public void Delete(Examination entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(Examination entity)
        {
            throw new NotImplementedException();
        }

        public Examination Get(long id)
            => myDbContext.Examination.FirstOrDefault(examination => examination.Id == id);

        public IEnumerable<Examination> GetAllEager()
            => myDbContext.Examination.ToList();

        public Examination GetEager(long id)
        {
            Examination exam = Get(id);
            exam.Doctor = _doctorRepository.GetEager(exam.Doctor.GetId());
            exam.Diagnosis = _diagnosisRepository.Get(exam.Diagnosis.GetId());
            if (exam.Therapy != null)
                exam.Therapy = _therapyRepository.GetEager(exam.Therapy.GetId());
            if(exam.Refferal!=null)
                exam.Refferal = _referralRepository.GetEager(exam.Refferal.GetId());
            if(exam.Prescription!=null)
                exam.Prescription = _prescriptionRepository.GetEager(exam.Prescription.GetId()); 
            return exam;
        }

        public IEnumerable<Examination> GetEager()
        {
            throw new NotImplementedException();
        }

        public List<Examination> GetExaminationsByUser(User user)
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
            }
            catch 
            {
                Patient patient = (Patient)user;
                List<Examination> examinations = GetAllEager().ToList();
                List<Examination> findExamination = new List<Examination>();
                foreach (Examination examination in examinations)
                {
                    if (examination.Doctor.Id == patient.Id)
                    {
                        findExamination.Add(examination);
                    }
                }
                return findExamination;
            }
        }

        public Examination Save(Examination entity)
        {
            throw new NotImplementedException();
        }
    }
}