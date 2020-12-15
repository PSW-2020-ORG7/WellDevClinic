using bolnica.Repository;
using bolnica.Service;
using Model.Doctor;
using Model.PatientSecretary;
using Model.Users;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace bolnica.Service
{
    public class PatientService : IPatientService
    {

        private readonly IPatientRepository _patientRepository;
        private readonly IPatientFileService _patientFileService;
        private readonly IDoctorGradeService _doctorGradeService;
        private readonly IExaminationService _examinationService;

        public PatientService(IPatientRepository patientRepo)
        {
            _patientRepository = patientRepo;
        }

        public PatientService(IPatientRepository _patientRepo, IPatientFileService _servicePatientFile, IDoctorGradeService doctorGradeService, IExaminationService examinationService)
        {
            _doctorGradeService = doctorGradeService;
            _patientRepository = _patientRepo;
            _patientFileService = _servicePatientFile;
            _examinationService = examinationService;
        }

        public PatientService(IPatientRepository _patientRepo, IPatientFileService _servicePatientFile)
        {
            _patientRepository = _patientRepo;
            _patientFileService = _servicePatientFile;


        }
       
        

        public Patient Save(Patient entity)
        {
            
            Patient patient = new Patient();
            Patient patientId = _patientRepository.GetPatientByJMBG(entity.Jmbg);
            if (patientId == null)
            {
                _patientRepository.Save(entity);
                patient = null;
            }
            else
            {
                patient.Jmbg = patientId.Jmbg;
                patient = patientId;    
            }

            return patient;
        }

        public void Delete(Patient entity)
        {
            _patientRepository.Delete(entity);
        }

        public void Edit(Patient entity)
        {
            _patientRepository.Edit(entity);
        }

        public IEnumerable<Patient> GetAll()
        {
            return _patientRepository.GetEager();
        }

        public Patient Get(long id)
        {
            return _patientRepository.Get(id);
        }

        public Patient ClaimAccount(Patient patient)
        {
            if (GetUserByUsername(patient.Username) == null)
            {
                if (!patient.Phone.Equals("") && !patient.Email.Equals(""))
                {
                    patient.Guest = false;
                    Edit(patient);
                    return _patientRepository.GetEager(patient.GetId());
                }
            }
            return null;
        }

        public User GetUserByUsername(String username)
        {
            return _patientRepository.GetUserByUsername(username);
        }

        public Patient GetPatientByJMBG(string jmbg)
        {
            return _patientRepository.GetPatientByJMBG(jmbg);
        }

        public Patient GetPatientByMail(string email)
        {
            return _patientRepository.GetPatientByMail(email);
        }

        public Patient GetPatientByUsername(string username)
        {
            return _patientRepository.GetPatientByMail(username);
        }

        public Patient GetPatientToken(string token)
        {
            return _patientRepository.GetPatientToken(token);
        }

        public DoctorGrade GiveGradeToDoctor(Doctor doctor, Dictionary<string, double> gradesForDoctor)
        {
            DoctorGrade doctorGrade = doctor.DoctorGrade;

            doctorGrade.NumberOfGrades++;
            foreach(String question in doctorGrade.GradesForEachQuestions.Keys.ToList())
            {
                doctorGrade.GradesForEachQuestions[question] = (doctorGrade.GradesForEachQuestions[question]*(doctorGrade.NumberOfGrades-1) +
                                                                gradesForDoctor[question]) / doctorGrade.NumberOfGrades;
            }

             _doctorGradeService.Edit(doctorGrade);

            return doctorGrade;
        }


        public Patient CheckExistence(string jmbg, string username, string email)
        {
            Patient patient = new Patient();

            Patient patientId = _patientRepository.GetPatientByJMBG(jmbg);
            Patient patientEmail = _patientRepository.GetPatientByMail(email);
            Patient patientUsername = _patientRepository.GetPatientByUsername(username);

            if (patientId == null && patientEmail == null && patientUsername == null)
            {
                patient = null;
            }
            else
            {
                if (patientId != null)
                    patient.Jmbg = patientId.Jmbg;
                else if (patientEmail != null)
                    patient.Email = patientEmail.Email;
                else if (patientUsername != null)
                    patient.Username = patientUsername.Username;
            }

            return patient;
        }

        public List<Patient> GetPatientsForBlocking()
        {
            List<Patient> result = new List<Patient>();
            List<Patient> patients = GetUnblockedPatients();

            foreach(Patient patient in patients)
            {
                if(!patient.Blocked)
                {
                    List<DateTime> dates = _examinationService.GetCancelationDatesByPatient(patient.Id);
                    if (dates.Count>=3)
                        result.Add(patient);
                }

            }

            return result;
        }

        public List<Patient> GetBlockedPatients()
        {
            List<Patient> result = new List<Patient>();
            List<Patient> patients = (List<Patient>)GetAll();
            foreach (Patient patient in patients)
            {
                if (patient.Blocked)
                    result.Add(patient);
            }

            return result;
        }

        public List<Patient> GetUnblockedPatients()
        {
            List<Patient> result = new List<Patient>();
            List<Patient> patients = (List<Patient>)GetAll();
            foreach (Patient patient in patients)
            {
                if (!patient.Blocked)
                    result.Add(patient);
            }

            return result;
        }
    }
}
