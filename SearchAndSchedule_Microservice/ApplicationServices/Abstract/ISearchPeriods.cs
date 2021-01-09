using SearchAndSchedule_Microservice.ApplicationServices.DTObjects;
using SearchAndSchedule_Microservice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SearchAndSchedule_Microservice.ApplicationServices.Abstract
{
    public interface ISearchPeriods
    {
        List<ExaminationDTO> Search(BusinessDayDTO businessDayDTO, List<BusinessDay> businessDayCollection);
        List<ExaminationDTO> CreateExaminationDTO(BusinessDay businessDay);
        List<BusinessDay> DaysForExactPeriod(Period period, List<BusinessDay> businessDaysCollection);
    }
}
