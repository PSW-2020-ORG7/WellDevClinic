using SearchAndSchedule_Microservice.ApplicationServices.DTObjects;
using SearchAndSchedule_Microservice.Domain.Model;
using SearchAndSchedule_Microservice.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace SearchAndSchedule_Microservice.ApplicationServices.Abstract
{
    public interface  IBussinesDayAppService : ICRUD<BusinessDay, long>
    {
        List<ExaminationDTO> Search(BusinessDayDTO businessDayDTO);

        void MarkAsOccupied(List<Period> period, BusinessDay businessDay);
        BusinessDay GetExactDay(Doctor doctor, DateTime date);
        List<BusinessDay> GetBusinessDaysByDoctor(Doctor doctor);
        void DeleteBusinessDayByRoom(Room room);
        void FreePeriod(BusinessDay businessDay, List<DateTime> period);
        Boolean ChangeDoctorShift(BusinessDay newShift);
        Boolean IsExaminationPossible(UpcomingExamination examination);
        void SetPriority(PriorityType priority);
        public List<ExaminationDTO> OperationSearch(BusinessDayDTO businessDayDTO, double durationOfOperation);
    }
}
