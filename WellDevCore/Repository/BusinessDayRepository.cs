using bolnica;
using bolnica.Model;
using bolnica.Repository;
using Model.Director;
using Model.PatientSecretary;
using Model.Users;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
   public class BusinessDayRepository : IBusinessDayRepository
   {
        public IDoctorRepository _doctorRepository { get; set; }
        private readonly IRoomRepository _roomRepository;
        private readonly MyDbContext myDbContext;

        public BusinessDayRepository( IRoomRepository roomRepository, MyDbContext context)
        {
            //_doctorRepository = doctorRepository;
            _roomRepository = roomRepository;
            myDbContext = context;
        }

        public IEnumerable<BusinessDay> GetAllEager()
        {
            List<BusinessDay> businessDays = new List<BusinessDay>();
            foreach(BusinessDay day in GetEager().ToList())
            {
                businessDays.Add(GetEager(day.GetId()));
            }

            return businessDays;
        }

        public List<BusinessDay> GetBusinessDaysByDate(DateTime date)
        {
           
            List<BusinessDay> businessDays = GetAllEager().ToList();
            List<BusinessDay> retVal = new List<BusinessDay>();
                foreach (BusinessDay day in businessDays)
                {
                    if (day.Shift.StartDate.Date == date.Date)
                        retVal.Add(day);
                }

            return retVal;
        }

        public BusinessDay GetEager(long id)
        {
            BusinessDay businessDay = Get(id);
            //businessDay.doctor = _doctorRepository.Get(businessDay.doctor.GetId());
            businessDay.room = _roomRepository.GetEager(businessDay.room.GetId());
            return businessDay;
        }

        public BusinessDay Save(BusinessDay entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(BusinessDay entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(BusinessDay entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BusinessDay> GetEager()
        {
            List<BusinessDay> result = new List<BusinessDay>();
            myDbContext.BusinessDay.ToList().ForEach(businessDay => result.Add(businessDay));
            return result;
        }

        public BusinessDay Get(long id)
            => myDbContext.BusinessDay.FirstOrDefault(businessDay => businessDay.Id == id);

    }
}