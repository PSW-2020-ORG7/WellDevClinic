using Controller;
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
        List<Examination> GetExaminationsByFilter(ExaminationDTO examinationDTO, Boolean upcomingOnly);
        List<Examination> GetAllPrevious();
        List<Examination> SearchPreviousExamination(String date, String doctorName, String drugName, String speacialistName, long id);
        List<Examination> SearchPreviousExaminations(String date, String doctorName, String drugName, String speacialistName, Boolean Radio1, Boolean Radio2);
        void EditPrevious(Examination entity);
        Examination GetPrevious(long id);

    }
}
