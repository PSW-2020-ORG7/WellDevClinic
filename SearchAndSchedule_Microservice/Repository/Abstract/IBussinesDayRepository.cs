using SearchAndSchedule_Microservice.ApplicationServices.Abstract;
using SearchAndSchedule_Microservice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SearchAndSchedule_Microservice.Repository.Abstract
{
    public interface IBussinesDayRepository : ICRUD<BusinessDay, long>
    {
        IEnumerable<BusinessDay> GetBusinessDaysByDoctor(Doctor doctor);
        IEnumerable<BusinessDay> GetBusinessDaysByRoom(Room room);
        void DeleteRange(List<BusinessDay> businessDays);
        BusinessDay GetExactDay(Doctor doctor, DateTime date);
    }
}
