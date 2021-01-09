using Controller;
using Model.Director;
using Model.Dto;
using Model.PatientSecretary;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Controller
{
    public interface IExaminationController : IController<Examination, long>
    {
        Examination SaveFinishedExamination(Examination examination);
        List<Examination> GetUpcomingExaminationsByUser(long id);
        List<Examination> GetFinishedExaminationsByUser(long id);
        List<Examination> GetUpcomingExaminationsByUser(User user);
        List<Examination> GetFinishedExaminationsByUser(User user);
        IEnumerable<Examination> GetUpcomingExaminationsByRoomAndPeriod(Room room, Period period);

        List<Examination> GetExaminationsByFilter(ExaminationDTO examinationDTO, Boolean upcomingOnly);
        List<Examination> GetAllPrevious();
        Examination NewExamination(long DoctorId, Period Period, long PatientId);
        void EditPrevious(Examination entity);
        Examination GetPrevious(long id);
        List<Examination> GetAllUpcomingExaminations();

    }
}
