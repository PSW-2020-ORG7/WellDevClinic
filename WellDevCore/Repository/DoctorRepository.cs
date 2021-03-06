using Model.Doctor;
using Model.Users;
using System;
using System.Collections.Generic;
using bolnica.Repository;
using System.Linq;
using Service;
using bolnica.Model;
using bolnica;

namespace Repository
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly IBusinessDayRepository _businessDayRepository;
        private readonly ISpecialityRepository _specialityRepository;
        private readonly IDoctorGradeRepository _doctorGradeRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly ITownRepository _townRepository;
        private readonly IStateRepository _stateRepository;

        private readonly MyDbContext myDbContext;

        public DoctorRepository(IBusinessDayRepository businessDayRepository, ISpecialityRepository specialityRepository, IDoctorGradeRepository doctorGradeRepository, IAddressRepository addressRepository, ITownRepository townRepository, IStateRepository stateRepository, MyDbContext context)
        {
            _businessDayRepository = businessDayRepository;
            _specialityRepository = specialityRepository;
            _doctorGradeRepository = doctorGradeRepository;
            _addressRepository = addressRepository;
            _townRepository = townRepository;
            _stateRepository = stateRepository;
            //myDbContext = _myDbContext;
            myDbContext = context;
        }

        public IEnumerable<Doctor> GetAllEager()
        {
            List<Doctor> doctors = new List<Doctor>();
            foreach (Doctor doctor in GetEager().ToList())
            {
                doctors.Add(GetEager(doctor.GetId()));
            }
            return doctors;
        }

        public Doctor GetEager(long id)
        {
            Doctor doctor = Get(id);
            /*foreach(BusinessDay businessDay in doctor.BusinessDay)
            {
                businessDay.doctor = null;
            }*/
           

            /*
            List<BusinessDay> businessDays = new List<BusinessDay>();

            if (doctor.BusinessDay != null)
            {
                foreach (BusinessDay day in doctor.BusinessDay)
                {
                   // day.doctor = null;
                    businessDays.Add(_businessDayRepository.GetEager(day.GetId()));
                }
            }

            doctor.BusinessDay = businessDays;
            */
            doctor.Specialty = _specialityRepository.Get(doctor.Specialty.GetId());
            //doctor.Address = _addressRepository.GetEager(doctor.Address.GetId());
            //doctor.Address.Town = _townRepository.GetEager(doctor.Address.Town.GetId());
            //doctor.Address.Town.State = _stateRepository.GetEager(doctor.Address.Town.State.GetId());
            //doctor.DoctorGrade = _doctorGradeRepository.Get(doctor.DoctorGrade.GetId());


            return doctor;
        }

        public User GetUserByUsername(string username)
        {
            IEnumerable<Doctor> entities = this.GetAllEager().ToList();
            foreach (Doctor entity in entities)
            {
                if (entity.Username.Equals(username))
                    return entity;
            }
            return null;
        }

        public Doctor Save(Doctor entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(Doctor entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Doctor entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Doctor> GetEager()
        {
            List<Doctor> result = new List<Doctor>();
            myDbContext.Doctor.ToList().ForEach(doctor => result.Add(doctor));
            return result;
        }

        public Doctor Get(long id)
            => myDbContext.Doctor.FirstOrDefault(doctor => doctor.Id == id);

    }
}
