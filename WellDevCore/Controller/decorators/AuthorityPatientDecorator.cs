using Model.Doctor;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Controller.decorators
{
    public class AuthorityPatientDecorator : IPatientController
    {
        private IPatientController PatientController;
        private String Role;
        private Dictionary<String, List<String>> AuthorizedUsers;

        public AuthorityPatientDecorator(IPatientController patientController, String role)
        {
            this.PatientController = patientController;
            this.Role = role;
            AuthorizedUsers = new Dictionary<string, List<string>>();
            AuthorizedUsers["ClaimAccount"] = new List<string>() {"Patient"};
            AuthorizedUsers["Delete"] = new List<string>() {"Patient", "Director"};
            AuthorizedUsers["Edit"] = new List<string>() {"Patient"};
            AuthorizedUsers["Get"] = new List<string>() {"Patient", "Secretary", "Doctor"};
            AuthorizedUsers["GetAll"] = new List<string>() { "Secretary", "Doctor"};
            AuthorizedUsers["GetPatientByJMBG"] = new List<string>() {"Patient", "Secretary"};
            AuthorizedUsers["GiveGradeToDoctor"] = new List<string>() {"Patient"};
            AuthorizedUsers["Save"] = new List<string>() {"Patient", "Secretary"};
            AuthorizedUsers["GetPatientByMail"] = new List<string>() { "Patient" };
            AuthorizedUsers["GetPatientByUsername"] = new List<string>() { "Patient" };
        }

        public Patient ClaimAccount(Patient patient)
        {
            if (AuthorizedUsers["ClaimAccount"].SingleOrDefault(any => any.Equals(Role)) != null)
                return PatientController.ClaimAccount(patient);
            return null;
        }

        public void Delete(Patient entity)
        {
            if (AuthorizedUsers["Delete"].SingleOrDefault(any => any.Equals(Role)) != null)
                PatientController.Delete(entity);
        }

        public void Edit(Patient entity)
        {
            if (AuthorizedUsers["Edit"].SingleOrDefault(any => any.Equals(Role)) != null)
                PatientController.Edit(entity);
        }

        public Patient Get(long id)
        {
            if (AuthorizedUsers["Get"].SingleOrDefault(any => any.Equals(Role)) != null)
                return PatientController.Get(id);
            return null;
        }

        public IEnumerable<Patient> GetAll()
        {
            if (AuthorizedUsers["GetAll"].SingleOrDefault(any => any.Equals(Role)) != null)
                return PatientController.GetAll();
            return null;
        }
        
        public Patient GetPatientByJMBG(string jmbg)
        {
            if (AuthorizedUsers["GetPatientByJMBG"].SingleOrDefault(any => any.Equals(Role)) != null)
                return PatientController.GetPatientByJMBG(jmbg);
            return null;
        }

        public Patient CheckExistence(String jmbg, String username, String email)
        {
            if (AuthorizedUsers["CheckExistence"].SingleOrDefault(any => any.Equals(Role)) != null)
                return PatientController.CheckExistence(jmbg,username,email);
            return null;
        }

        /*
        public Patient GetPatientByMail(string email)
        {
            if (AuthorizedUsers["GetAll"].SingleOrDefault(any => any.Equals(Role)) != null)
                return PatientController.GetPatientByMail(email);
            return null;
        }

        public Patient GetPatientByUsername(string username)
        {
            if (AuthorizedUsers["GetAll"].SingleOrDefault(any => any.Equals(Role)) != null)
                return PatientController.GetPatientByUsername(username);
            return null;
        } */

        public DoctorGrade GiveGradeToDoctor(Doctor doctor, Dictionary<string, double> gradesForDoctor)
        {
            if (AuthorizedUsers["GiveGradeToDoctor"].SingleOrDefault(any => any.Equals(Role)) != null)
                return PatientController.GiveGradeToDoctor(doctor, gradesForDoctor);
            return null;
        }

        public Patient Save(Patient entity)
        {
            if (AuthorizedUsers["Save"].SingleOrDefault(any => any.Equals(Role)) != null)
                return PatientController.Save(entity);
            return null;
        }

        public List<Patient> GetPatientsForBlocking()
        {
            if (AuthorizedUsers["GetPatientsForBlocking"].SingleOrDefault(any => any.Equals(Role)) != null)
                return PatientController.GetPatientsForBlocking();
            return null;
        }

        public List<Patient> GetBlockedPatients()
        {
            if (AuthorizedUsers["GetBlockedPatients"].SingleOrDefault(any => any.Equals(Role)) != null)
                return PatientController.GetBlockedPatients();
            return null;
        }

        public Patient GetPatientToken(string token)
        {
            if (AuthorizedUsers["GetPatientToken"].SingleOrDefault(any => any.Equals(Role)) != null)
                return PatientController.GetPatientToken(token);
            return null;
        }
    }
}
