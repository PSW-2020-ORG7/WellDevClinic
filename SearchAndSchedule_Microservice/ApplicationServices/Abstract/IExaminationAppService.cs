using SearchAndSchedule_Microservice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SearchAndSchedule_Microservice.ApplicationServices.Abstract
{
    public interface IExaminationAppService : ICRUD<UpcomingExamination,long>
    {
        public List<UpcomingExamination> GetUpcomingExaminationsByDoctor(Doctor doctor);
        public List<UpcomingExamination> GetUpcomingExaminationsByPatient(Patient patient);
        public Room GetExaminationRoom(UpcomingExamination examination);
        public List<UpcomingExamination> GetUpcomingExaminationsByRoomAndPeriod(Room room, Period period);

    }
}
