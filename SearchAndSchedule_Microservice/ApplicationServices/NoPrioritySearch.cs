using SearchAndSchedule_Microservice.ApplicationServices.Abstract;
using SearchAndSchedule_Microservice.ApplicationServices.DTObjects;
using SearchAndSchedule_Microservice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SearchAndSchedule_Microservice.ApplicationServices
{
    public class NoPrioritySearch : ISearchPeriods
    {
        public NoPrioritySearch() { }

        [Obsolete]
        public List<ExaminationDTO> Search(BusinessDayDTO businessDayDTO, List<BusinessDay> businessDayCollection)
        {                               // businessDay napravljen, svi biznis dani lekara
            List<BusinessDay> IterationDays = DaysForExactPeriod(businessDayDTO.Period, businessDayDTO.Doctor.BussinesDays);
            if (IterationDays != null)
            {
                foreach (BusinessDay day in IterationDays)
                {
                    List<ExaminationDTO> retVal = CreateExaminationDTO(day);
                    if (retVal != null)
                    {
                        return retVal;
                    }
                }
            }
            return null;
        }
        [Obsolete]
        public List<ExaminationDTO> CreateExaminationDTO(BusinessDay businessDay)
        {
            List<ExaminationDTO> retVal = new List<ExaminationDTO>();
            DateTime Start = businessDay.Shift.StartDate;
            DateTime End = Start.AddMinutes(BusinessDayAppService.durationOfExamination);
            while (End <= businessDay.Shift.EndDate)
            {
                if (businessDay.ScheduledPeriods.SingleOrDefault(x => x.StartDate == Start) == null)
                {
                    ExaminationDTO examinationDTO = new ExaminationDTO
                    {
                        Room = businessDay.Room,
                        Period = new Period(Start, End),
                        Doctor = businessDay.Doctor
                    };
                    retVal.Add(examinationDTO);
                }
                End = End.AddMinutes(BusinessDayAppService.durationOfExamination);
                Start = Start.AddMinutes(BusinessDayAppService.durationOfExamination);
            }
            return retVal;
        }

        public List<BusinessDay> DaysForExactPeriod(Period period, List<BusinessDay> businessDaysCollection)
        {
            List<BusinessDay> businessDays = new List<BusinessDay>();
            if (businessDaysCollection != null)
            {
                foreach (BusinessDay day in businessDaysCollection)
                {
                    if (day.Shift.StartDate.Date == period.StartDate.Date)
                    {
                        businessDays.Add(day);
                        return businessDays;
                    }
                }
            }
            return null;
        }
    }
}
