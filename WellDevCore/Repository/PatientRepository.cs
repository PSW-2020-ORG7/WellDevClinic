

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
   public class PatientRepository : IPatientRepository, IEagerRepository<Patient,long>
   {
        private readonly IPatientFileRepository _patientFleRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly ITownRepository _townRepository;
        private readonly IStateRepository _stateRepository;

        private readonly MyDbContext myDbContext;

        public PatientRepository(IPatientFileRepository patientFleRepository, IAddressRepository addressRepository, ITownRepository townRepository, IStateRepository stateRepository, MyDbContext context)
        {
            _patientFleRepository = patientFleRepository;
            _addressRepository = addressRepository;
            _townRepository = townRepository;
            _stateRepository = stateRepository;
            myDbContext = context;
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
            => myDbContext.Patient.FirstOrDefault(patient => patient.Id == id);
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
            List<Patient> patients = GetAllEager().ToList();
            foreach(Patient patient in patients){
                if (patient.Jmbg.Equals(jmbg))
                {
                    return patient;
                }
            }
            return null;
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

        public Patient Save(Patient entity)
        {
            throw new NotImplementedException();
        }
    }
}