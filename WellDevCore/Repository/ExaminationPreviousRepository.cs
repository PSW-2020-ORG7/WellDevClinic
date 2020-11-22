using bolnica;
using bolnica.Model;
using bolnica.Repository;
using Model.PatientSecretary;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class ExaminationPreviousRepository : CSVRepository<Examination, long>, IExaminationPreviousRepository
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IDiagnosisRepository _diagnosisRepository;
        private readonly IPrescriptionRepository _prescriptionRepository;
        private readonly ITherapyRepository _therapyRepository;
        private readonly IReferralRepository _referralRepository;
        private readonly MyDbContext myDbContext;

        /*public ExaminationPreviousRepository(IDoctorRepository doctorRepository, IPatientRepository patientRepository, IDiagnosisRepository diagnosisRepository, IPrescriptionRepository prescriptionRepository, ITherapyRepository therapyRepository, IReferralRepository referralRepository)
        {
            _doctorRepository = doctorRepository;
            _patientRepository = patientRepository;
            _diagnosisRepository = diagnosisRepository;
            _prescriptionRepository = prescriptionRepository;
            _therapyRepository = therapyRepository;
            _referralRepository = referralRepository;
            MyContextContextFactory mccf = new MyContextContextFactory();
            this.myDbContext = mccf.CreateDbContext(new string[0]);
        }*/

        public ExaminationPreviousRepository(ICSVStream<Examination> stream, ISequencer<long> sequencer, IDoctorRepository doctorRepository, IPatientRepository patientRepository, IDiagnosisRepository diagnosisRepository, IPrescriptionRepository prescriptionRepository, ITherapyRepository therapyRepository, IReferralRepository referralRepository)
 : base(stream, sequencer)
        {
            _doctorRepository = doctorRepository;
            _patientRepository = patientRepository;
            _diagnosisRepository = diagnosisRepository;
            _prescriptionRepository = prescriptionRepository;
            _therapyRepository = therapyRepository;
            _referralRepository = referralRepository;
            MyContextContextFactory mccf = new MyContextContextFactory();
            this.myDbContext = mccf.CreateDbContext(new string[0]);
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

        public IEnumerable<Examination> GetAll()
        {
            List<Examination> result = new List<Examination>();
            myDbContext.Examination.ToList().ForEach(examination => result.Add(examination));
            return result;
        }

        public IEnumerable<Examination> GetAllEager()
        {
            List<Examination> examinations = new List<Examination>();
            foreach (Examination exam in GetAll().ToList())
            {
                examinations.Add(GetEager(exam.GetId()));
            }
            return examinations;
        }

        public Examination GetEager(long id)
        {
            Examination exam = myDbContext.Examination.Find(id);
            exam.Doctor = _doctorRepository.GetEager(exam.Doctor.GetId());
            exam.User = _patientRepository.Get(exam.User.GetId());
            exam.Diagnosis = _diagnosisRepository.Get(exam.Diagnosis.GetId());
            if (exam.Therapy != null)
                exam.Therapy = _therapyRepository.GetEager(exam.Therapy.GetId());
            if(exam.Refferal!=null)
                exam.Refferal = _referralRepository.GetEager(exam.Refferal.GetId());
            if(exam.Prescription!=null)
                exam.Prescription = _prescriptionRepository.GetEager(exam.Prescription.GetId());  
            return exam;
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