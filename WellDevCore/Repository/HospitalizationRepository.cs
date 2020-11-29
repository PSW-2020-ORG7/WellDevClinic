using bolnica;
using bolnica.Model;
using bolnica.Repository;
using Model.Director;
using Model.Doctor;
using Model.PatientSecretary;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Repository
{
   public class HospitalizationRepository : IHospitalizationRepository
    {
        private readonly IRoomRepository _roomRepository;
        //private readonly IPatientRepository _patientRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly MyDbContext myDbContext;

        public HospitalizationRepository(IRoomRepository roomRepository, IDoctorRepository doctorRepository, MyDbContext context)
        {
            _roomRepository = roomRepository;
           // _patientRepository = patientRepository;
            _doctorRepository = doctorRepository;
            myDbContext = context;
        }

        /*public HospitalizationRepository(ICSVStream<Hospitalization> stream, ISequencer<long> sequencer, IRoomRepository roomRepository, IPatientRepository patientRepository, IDoctorRepository doctorRepository)
    : base(stream, sequencer)
        {
            _patientRepository = patientRepository;
            _roomRepository = roomRepository;
            _doctorRepository = doctorRepository;
            MyContextContextFactory mccf = new MyContextContextFactory();
            this.myDbContext = mccf.CreateDbContext(new string[0]);
        }*/

        public void Delete(Hospitalization entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(Hospitalization entity)
        {
            throw new NotImplementedException();
        }

        public Hospitalization Get(long id)
            => myDbContext.Hospitalization.FirstOrDefault(hospitalization => hospitalization.Id == id);

        public IEnumerable<Hospitalization> GetEager()
        {
            List<Hospitalization> result = new List<Hospitalization>();
            myDbContext.Hospitalization.ToList().ForEach(hospitalization => result.Add(hospitalization));
            return result;
        }

        public IEnumerable<Hospitalization> GetAllEager()
        {
            List<Hospitalization> hospitalizations = new List<Hospitalization>();
            foreach(Hospitalization hospitalization in GetEager().ToList())
            {
                hospitalizations.Add(GetEager(hospitalization.GetId()));
            }
            return hospitalizations;
        }

        public Hospitalization GetEager(long id)
        {
            Hospitalization hospitalization = Get(id);
            hospitalization.Room=_roomRepository.GetEager(hospitalization.Room.GetId());
           // hospitalization.Patient = _patientRepository.Get(hospitalization.Patient.GetId());
            hospitalization.Doctor = _doctorRepository.GetEager(hospitalization.Doctor.GetId());
            return hospitalization;
        }

        public List<Hospitalization> GetHospitalizationByDoctor(Doctor doctor)
        {
            List<Hospitalization> hospitalizations = this.GetAllEager().ToList();
            List<Hospitalization> retVal = new List<Hospitalization>();
            foreach (Hospitalization hospitalization in hospitalizations)
            {
                if (hospitalization.Doctor.Id == doctor.Id)
                {
                    retVal.Add(hospitalization);
                }
            }
            return retVal;
        }

        public Hospitalization Save(Hospitalization entity)
        {
            throw new NotImplementedException();
        }
    }
}