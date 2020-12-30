using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserInteraction_Microservice.ApplicationServices.Abstract;
using UserInteraction_Microservice.Domain.Model;

namespace UserInteraction_Microservice.Decorators
{
    public class AuthorityPatientDecorator : IPatientAppService
    {
        private IPatientAppService _patientAppService;
        private String Role;
        private Dictionary<String, List<String>> AuthorizedUsers;

        public AuthorityPatientDecorator(IPatientAppService patientAppService, String role)
        {
            this._patientAppService = patientAppService;
            this.Role = role;
            AuthorizedUsers = new Dictionary<string, List<string>>();
            AuthorizedUsers["ClaimAccount"] = new List<string>() { "Patient" };
            AuthorizedUsers["Delete"] = new List<string>() { "Patient", "Director" };
            AuthorizedUsers["Edit"] = new List<string>() { "Patient" };
            AuthorizedUsers["Get"] = new List<string>() { "Patient", "Secretary", "Doctor" };
            AuthorizedUsers["GetAll"] = new List<string>() { "Secretary", "Doctor" };
            AuthorizedUsers["GetPatientByJMBG"] = new List<string>() { "Patient", "Secretary" };
            AuthorizedUsers["GiveGradeToDoctor"] = new List<string>() { "Patient" };
            AuthorizedUsers["Save"] = new List<string>() { "Patient", "Secretary" };
            AuthorizedUsers["GetPatientByMail"] = new List<string>() { "Patient" };
            AuthorizedUsers["GetPatientByUsername"] = new List<string>() { "Patient" };
            AuthorizedUsers["GetAllEager"] = new List<string>() { "Secretary" };
            AuthorizedUsers["GetEager"] = new List<string>() { "Secretary", "Patient" };
            AuthorizedUsers["GradeDoctor"] = new List<string>() {"Patient" };


        }

        public Patient ClaimAccount(Patient patient)
        {
            if (AuthorizedUsers["ClaimAccount"].SingleOrDefault(any => any.Equals(Role)) != null)
                return _patientAppService.ClaimAccount(patient);
            return null;
        }

        public void Delete(Patient entity)
        {
            if (AuthorizedUsers["Delete"].SingleOrDefault(any => any.Equals(Role)) != null)
                _patientAppService.Delete(entity);
        }

        public void Edit(Patient entity)
        {
            if (AuthorizedUsers["Edit"].SingleOrDefault(any => any.Equals(Role)) != null)
                _patientAppService.Edit(entity);
        }

        public Patient Get(long id)
        {
            if (AuthorizedUsers["Get"].SingleOrDefault(any => any.Equals(Role)) != null)
                return _patientAppService.Get(id);
            return null;
        }

        public IEnumerable<Patient> GetAll()
        {
            if (AuthorizedUsers["GetAll"].SingleOrDefault(any => any.Equals(Role)) != null)
                return _patientAppService.GetAll();
            return null;
        }

        public Patient GetPatientByJMBG(string jmbg)
        {
            if (AuthorizedUsers["GetPatientByJMBG"].SingleOrDefault(any => any.Equals(Role)) != null)
                return _patientAppService.GetPatientByJMBG(jmbg);
            return null;
        }


        public Patient Save(Patient entity)
        {
            if (AuthorizedUsers["Save"].SingleOrDefault(any => any.Equals(Role)) != null)
                return _patientAppService.Save(entity);
            return null;
        }

        public List<Patient> GetPatientsForBlocking()
        {
            if (AuthorizedUsers["GetPatientsForBlocking"].SingleOrDefault(any => any.Equals(Role)) != null)
                return _patientAppService.GetPatientsForBlocking();
            return null;
        }

        public List<Patient> GetBlockedPatients()
        {
            if (AuthorizedUsers["GetBlockedPatients"].SingleOrDefault(any => any.Equals(Role)) != null)
                return _patientAppService.GetBlockedPatients();
            return null;
        }

        public Patient GetPatientToken(string token)
        {
            if (AuthorizedUsers["GetPatientToken"].SingleOrDefault(any => any.Equals(Role)) != null)
                return _patientAppService.GetPatientToken(token);
            return null;
        }

        public Patient LogIn(string username, string password)
        {
            return _patientAppService.LogIn(username, password);
        }

        public Patient GetEager(long id)
        {
            if (AuthorizedUsers["GetEager"].SingleOrDefault(any => any.Equals(Role)) != null)
                return _patientAppService.GetEager(id);
            return null;
        }

        public IEnumerable<Patient> GetAllEager()
        {
            if (AuthorizedUsers["GetAllEager"].SingleOrDefault(any => any.Equals(Role)) != null)
                return _patientAppService.GetAllEager();
            return null;
        }

        public DoctorGrade GradeDoctor(DoctorGrade doctorGrade, Doctor doctor)
        {
            throw new NotImplementedException();
        }
    }
}
