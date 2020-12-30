using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserInteraction_Microservice.ApplicationServices.Abstract;
using UserInteraction_Microservice.Domain.Model;

namespace UserInteraction_Microservice.Decorators
{
    public class AuthorityDoctorDecorator : IDoctorAppService
    {
        private IDoctorAppService _doctorAppService;
        private String Role;
        private Dictionary<String, List<String>> AuthorizedUsers;

        public AuthorityDoctorDecorator(IDoctorAppService doctorAppService, String role)
        {
            this._doctorAppService = doctorAppService;
            this.Role = role;
            AuthorizedUsers = new Dictionary<string, List<string>>();
            AuthorizedUsers["Delete"] = new List<string>() { "Director" };
            AuthorizedUsers["Edit"] = new List<string>() { "Director", "Doctor" };
            AuthorizedUsers["Get"] = new List<string>() { "Director", "Doctor", "Secretary" };
            AuthorizedUsers["GetAll"] = new List<string>() { "Director", "Doctor", "Secretary" };
            AuthorizedUsers["GetDoctorsBySpeciality"] = new List<string>() { "Doctor", "Patient" };
            AuthorizedUsers["Save"] = new List<string>() { "Director" };
            AuthorizedUsers["GetAllEager"] = new List<string>() { "Director" };
            AuthorizedUsers["GetEager"] = new List<string>() { "Director", "Secretary", "Doctor" };

        }


        public void Delete(Doctor entity)
        {
            if (AuthorizedUsers["Delete"].SingleOrDefault(any => any.Equals(Role)) != null)
                _doctorAppService.Delete(entity);
        }

        public void Edit(Doctor entity)
        {
            if (AuthorizedUsers["Edit"].SingleOrDefault(any => any.Equals(Role)) != null)
                _doctorAppService.Edit(entity);
        }

        public Doctor Get(long id)
        {
            if (AuthorizedUsers["Get"].SingleOrDefault(any => any.Equals(Role)) != null)
                return _doctorAppService.Get(id);
            return null;
        }

        public IEnumerable<Doctor> GetAll()
        {
            if (AuthorizedUsers["GetAll"].SingleOrDefault(any => any.Equals(Role)) != null)
                return _doctorAppService.GetAll();
            return null;
        }

        public IEnumerable<Doctor> GetAllEager()
        {
            if (AuthorizedUsers["GetAllEager"].SingleOrDefault(any => any.Equals(Role)) != null)
                return _doctorAppService.GetAllEager();
            return null;
        }

        public IEnumerable<Doctor> GetDoctorsBySpeciality(Speciality specialty)
        {
            if (AuthorizedUsers["GetDoctorsBySpeciality"].SingleOrDefault(any => any.Equals(Role)) != null)
                return _doctorAppService.GetDoctorsBySpeciality(specialty);
            return null;
        }

        public Doctor GetEager(long id)
        {
            if (AuthorizedUsers["GetEager"].SingleOrDefault(any => any.Equals(Role)) != null)
                return _doctorAppService.GetEager(id);
            return null;
        }

        public Doctor LogIn(string username, string password)
        {
            return _doctorAppService.LogIn(username, password);
        }

        public Doctor Save(Doctor entity)
        {
            if (AuthorizedUsers["Save"].SingleOrDefault(any => any.Equals(Role)) != null)
                return _doctorAppService.Save(entity);
            return null;
        }
    }
}
