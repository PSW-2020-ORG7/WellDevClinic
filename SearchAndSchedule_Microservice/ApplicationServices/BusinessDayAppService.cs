using SearchAndSchedule_Microservice.ApplicationServices.Abstract;
using SearchAndSchedule_Microservice.ApplicationServices.DTObjects;
using SearchAndSchedule_Microservice.Domain.Model;
using SearchAndSchedule_Microservice.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SearchAndSchedule_Microservice.ApplicationServices
{
    public class BusinessDayAppService : IBussinesDayAppService
    {
        private readonly IBussinesDayRepository _bussinesDayRepository;
        private  ISearchPeriods SearchPeriods { get; set; }
        public static double durationOfExamination = 30;

        public BusinessDayAppService(IBussinesDayRepository bussinesDayRepository)
        {
            _bussinesDayRepository = bussinesDayRepository;
            SearchPeriods = new NoPrioritySearch();
        }

        public BusinessDay Save(BusinessDay entity)
        {
            return _bussinesDayRepository.Save(entity);
        }

        public List<ExaminationDTO> OperationSearch(BusinessDayDTO businessDayDTO, double durationOfOperation)
        {
            List<ExaminationDTO> retVal = new List<ExaminationDTO>();
            SearchPeriods = new NoPrioritySearch();
            List<ExaminationDTO> timeSlots = Search(businessDayDTO);

            if (timeSlots == null)
                return null;

            double MinutesFree = 0;
            foreach (ExaminationDTO examinationDTO in timeSlots)
            {
                if (retVal.Count == 0)
                {
                    retVal.Add(examinationDTO);
                    MinutesFree = MinutesFree + durationOfExamination;
                }
                else
                {
                    if (retVal.SingleOrDefault(any => any.Period.StartDate.AddMinutes(durationOfExamination) == examinationDTO.Period.StartDate) != null)
                    {
                        retVal.Add(examinationDTO);
                        MinutesFree += durationOfExamination;
                    }
                    else
                    {
                        retVal.Clear();
                        retVal.Add(examinationDTO);
                        MinutesFree = durationOfExamination;
                    }
                }
                if (durationOfOperation == MinutesFree)
                    break;

            }

            return retVal;

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



        public bool IsExaminationPossible(UpcomingExamination examination)
        {
            SearchPeriods = new NoPrioritySearch();
            List<ExaminationDTO> examinations = Search(new BusinessDayDTO(examination.Doctor, examination.Period));
            foreach (ExaminationDTO exam in examinations)
            {
                if (exam.Period.StartDate == examination.Period.StartDate)
                    return true;
            }
            return false;
        }

        public List<ExaminationDTO> Search(BusinessDayDTO businessDayDTO)
        {
            TimeSpan difference = businessDayDTO.Period.StartDate - DateTime.Now;   //da se ne izabere datum pre danasnjeg
            SetPriority(businessDayDTO.Priority);
            if (difference.Days < 0)
            {
                /*if(businessDayDTO.PatientScheduling)
                {
                    if(_searchPeriods.GetType() != typeof(NoPrioritySearch))
                        businessDayDTO.Period.StartDate = businessDayDTO.Period.StartDate.AddDays(Double.Parse(ConfigurationSettings.AppSettings["scheduleRestriction"]));
                    else
                        return null;
                }*/
                return null;
            }
            businessDayDTO.Doctor.BussinesDays = GetBusinessDaysByDoctor(businessDayDTO.Doctor);           // uzima odredjenog doktora
            List<BusinessDay> businessDayCollection = _bussinesDayRepository.GetAll().ToList();    // uzima sve buduce businessDay
            return SearchPeriods.Search(businessDayDTO, businessDayCollection);
        }

        public void SetPriority(PriorityType priority)
        {
            if (priority == PriorityType.Doctor)
            {
                this.SearchPeriods = new DoctorPrioritySearch();
            }
            else if (priority == PriorityType.Date)
            {
                this.SearchPeriods = new DatePrioritySearch();
            }
            else
            {
                this.SearchPeriods = new NoPrioritySearch();
            }
        }

    }
}
