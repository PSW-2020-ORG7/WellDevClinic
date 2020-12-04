

using bolnica;
using bolnica.Model;
using bolnica.Repository;
using Model.PatientSecretary;
using Model.Users;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Repository
{
   public class PatientRepository : IPatientRepository, IEagerRepository<Patient,long>
   {
        private readonly IPatientFileRepository _patientFleRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly ITownRepository _townRepository;
        private readonly IStateRepository _stateRepository;

        private readonly MyDbContext myDbContext;

        public PatientRepository(IPatientFileRepository patientFileRepository, IAddressRepository addressRepository, ITownRepository townRepository, IStateRepository stateRepository, MyDbContext context)
        {
            this._patientFleRepository = patientFileRepository;
            this._addressRepository = addressRepository;
            this._townRepository = townRepository;
            this._stateRepository = stateRepository;
            this.myDbContext = context;
        }
        public void Delete(Patient entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(Patient entity)
        {
            throw new NotImplementedException();
        }

        public Patient Get(long id)
        {
            Patient patient = myDbContext.Patient.FirstOrDefault(patient => patient.Id == id);
            String filePath = "/StaticFiles/" + patient.Username + ".jpg";
            patient.Image = filePath;
            return patient;
        }
        public IEnumerable<Patient> GetEager()
        {
            List<Patient> result = new List<Patient>();
            myDbContext.Patient.ToList().ForEach(patient => result.Add(patient));
            return result;

        }

       
        public IEnumerable<Patient> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Patient> GetAllEager()
        {
            List<Patient> patients = new List<Patient>();
            foreach(Patient patient in GetEager().ToList())
            {
                patients.Add(GetEager(patient.GetId()));
            }

            return patients;
        }

        public Patient GetEager(long id)
        {
            Patient patient = Get(id);
            PatientFile patientfile = _patientFleRepository.GetEager(patient.patientFile.GetId());
            patient.patientFile = patientfile;
            patient.Address = _addressRepository.GetEager(patient.Address.GetId());
            patient.Address.Town = _townRepository.GetEager(patient.Address.Town.GetId());
            patient.Address.Town.State = _stateRepository.GetEager(patient.Address.Town.State.GetId());
            return patient;

        }

        public Patient GetPatientByJMBG(string jmbg)
        {
            Patient result = myDbContext.Patient.FirstOrDefault(patient => patient.Jmbg.Equals(jmbg));
            return result;
        }

        public Patient Save(Patient entity)
        {
            Patient retVal;
            Patient result = myDbContext.Patient.FirstOrDefault(patient => patient.Jmbg == entity.Jmbg);
            if (result == null)
            {
                string filePath = "profilePictures/" + entity.Username + ".jpg";
                string[] split = entity.Image.Split(';');
                string[] base64 = split[1].Split(',');
                string data = base64[1];
                File.WriteAllBytes(filePath, Convert.FromBase64String(data));
                entity.Image = entity.Username;
                myDbContext.Patient.Add(entity);
                myDbContext.SaveChanges();
                retVal = entity;
            }
            else
                retVal = null;

            return retVal;
        }

        public Patient GetPatientByMail(string email)
        {
            Patient result = myDbContext.Patient.FirstOrDefault(patient => patient.Email.Equals(email));
            return result;
        }

        public Patient GetPatientByUsername(string username)
        {
            Patient result = myDbContext.Patient.FirstOrDefault(patient => patient.Username.Equals(username));
            return result;
        }

        public Patient GetPatientToken(string token)
        {
            Patient result = myDbContext.Patient.FirstOrDefault(patient => patient.VerificationToken.Equals(token));
            return result;
        }

        public User GetUserByUsername(string username)
        {
            List<Patient> patients = GetAllEager().ToList();
            foreach (Patient patient in patients)
            {
                if (patient.Username.Equals(username))
                {
                    return patient;
                }
            }
            return null;
        }

        
    }
}