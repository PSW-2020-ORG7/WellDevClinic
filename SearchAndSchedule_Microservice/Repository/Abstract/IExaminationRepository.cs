using SearchAndSchedule_Microservice.ApplicationServices.Abstract;
using SearchAndSchedule_Microservice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SearchAndSchedule_Microservice.Repository.Abstract
{
    public interface IExaminationRepository : ICRUD<UpcomingExamination, long>
    {
        IEnumerable<UpcomingExamination> GetUpcomingExaminationsByDoctor(Doctor doctor);
        IEnumerable<UpcomingExamination> GetUpcomingExaminationsByPatient(Patient patient);
        List<UpcomingExamination> GetCanceledExaminations();
    }
}
