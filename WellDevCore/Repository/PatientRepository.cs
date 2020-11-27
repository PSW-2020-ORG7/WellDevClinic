

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
   public class PatientRepository : CSVRepository<Patient,long> ,IPatientRepository, IEagerRepository<Patient,long>
   {
        private readonly IPatientFileRepository _patientFleRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly ITownRepository _townRepository;
        private readonly IStateRepository _stateRepository;

        private readonly MyDbContext myDbContext;


        public PatientRepository(ICSVStream<Patient> stream, ISequencer<long> sequencer, IPatientFileRepository patientFileRepository, IAddressRepository addressRepository,
            ITownRepository townRepository, IStateRepository stateRepository)
            : base(stream, sequencer)
        {
            _patientFleRepository = patientFileRepository;
            _addressRepository = addressRepository;
            _townRepository = townRepository;
            _stateRepository = stateRepository;
            MyContextContextFactory mccf = new MyContextContextFactory();
            this.myDbContext = mccf.CreateDbContext(new string[0]);
        }

        public IEnumerable<Patient> GetAllEager()
        {
            List<Patient> patients = new List<Patient>();
            foreach(Patient patient in GetAll().ToList())
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
            Patient result = myDbContext.Patient.FirstOrDefault(patient => patient.Jmbg == entity.Jmbg);
            if (result == null)
            {
                myDbContext.Patient.Add(entity);
                myDbContext.SaveChanges();
                return entity;
            }

            return null;
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