using SearchAndSchedule_Microservice.ApplicationServices.Abstract;
using SearchAndSchedule_Microservice.ApplicationServices.DTObjects;
using SearchAndSchedule_Microservice.Domain.Model;
using SearchAndSchedule_Microservice.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SearchAndSchedule_Microservice.ApplicationServices
{
    public class BussinesDayAppService : IBussinesDayAppService
    {
        private readonly IBussinesDayRepository _bussinesDayRepository;
        private readonly ISearchPeriods _searchPeriods;
        public static double durationOfExamination = 30;

        public BussinesDayAppService(IBussinesDayRepository bussinesDayRepository)
        {
            _bussinesDayRepository = bussinesDayRepository;
        }

        public BusinessDay Save(BusinessDay entity)
        {
            return _bussinesDayRepository.Save(entity);
        }


        public void Delete(BusinessDay entity)
        {
            _bussinesDayRepository.Delete(entity);
        }

        public void Edit(BusinessDay entity)
        {
            _bussinesDayRepository.Edit(entity);
        }

        public BusinessDay Get(long id)
        {
            return _bussinesDayRepository.Get(id);
        }

        public IEnumerable<BusinessDay> GetAll()
        {
            return _bussinesDayRepository.GetAll();
        }

        public List<BusinessDay> GetBusinessDaysByDoctor(Doctor doctor)
        {
            return _bussinesDayRepository.GetBusinessDaysByDoctor(doctor).ToList();
        }

        public void DeleteBusinessDayByRoom(Room room)
        {
            List<BusinessDay> businessDays = _bussinesDayRepository.GetBusinessDaysByRoom(room).ToList();
            _bussinesDayRepository.DeleteRange(businessDays);
        }

        public bool ChangeDoctorShift(BusinessDay newShift)
        {
            TimeSpan shiftDuration = newShift.Shift.EndDate - newShift.Shift.StartDate;

            double periodTotalMinutes = 0;
            if (newShift.ScheduledPeriods == null)
                return true;

            foreach (Period period in newShift.ScheduledPeriods)
                periodTotalMinutes += durationOfExamination;


            if (shiftDuration.TotalMinutes < periodTotalMinutes)
                return false;

            foreach (Period period in newShift.ScheduledPeriods)
                if (period.ComparePeriod(newShift.Shift))
                    return false;

            return true;
        }

        public void MarkAsOccupied(List<Period> period, BusinessDay businessDay)
        {
            businessDay.ScheduledPeriods.AddRange(period);
            Edit(businessDay);
        }

        public void FreePeriod(BusinessDay businessDay, List<DateTime> periods)
        {
            foreach (DateTime period in periods)
                for (int i = 0; i < businessDay.ScheduledPeriods.Count; i++)
                {
                    if (businessDay.ScheduledPeriods[i].StartDate == period)
                    {
                        businessDay.ScheduledPeriods.RemoveAt(i--);
                        break;
                    }
                }

            Edit(businessDay);
        }


        public BusinessDay GetExactDay(Doctor doctor, DateTime date)
        {
            return _bussinesDayRepository.GetExactDay(doctor, date);
        }

        public bool IsExaminationPossible(Examination examination)
        {
            throw new NotImplementedException();
        }

        public List<Examination> Search(BusinessDayDTO businessDayDTO)
        {
            throw new NotImplementedException();
        }

        public void SetPriority(PriorityType priority)
        {
            throw new NotImplementedException();
        }
    }
}
