using bolnica.Controller;
using bolnica.Service;
using Model.Doctor;
using Model.Users;
using System;
using System.Collections.Generic;

namespace bolnica.Controller
{
    public class PatientController : IPatientController
    {
        private readonly IPatientService _patientService;

        public PatientController()
        {

        }

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        public Patient ClaimAccount(Patient patient)
        {
            return _patientService.ClaimAccount(patient);
        }

        public void Delete(Patient entity)
        {
            _patientService.Delete(entity);
        }

        public void Edit(Patient entity)
        {
            _patientService.Edit(entity);
        }

        public Patient Get(long id)
        {
            return _patientService.Get(id);
        }

        public IEnumerable<Patient> GetAll()
        {
            return _patientService.GetAll();
        }

        public Patient GetPatientByJMBG(string jmbg)
        {
            return _patientService.GetPatientByJMBG(jmbg);
        }

        public DoctorGrade GiveGradeToDoctor(Doctor doctor, Dictionary<string, double> gradesForDoctor)
        {
            return _patientService.GiveGradeToDoctor(doctor, gradesForDoctor);
        }

        public Patient Save(Patient entity)
        {
            return _patientService.Save(entity);
        }

        public Patient CheckExistence(String jmbg, String username, String email)
        {
            return null;
        }

        /*
        public Patient GetPatientByMail(string email)
        {
            return _patientService.GetPatientByMail(email);
        }

        public Patient GetPatientByUsername(string username)
        {
            return _patientService.GetPatientByUsername(username);
        }
        */
    }
}