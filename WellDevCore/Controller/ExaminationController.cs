using bolnica.Controller;
using bolnica.Service;
using Model.Dto;
using Model.PatientSecretary;
using Model.Users;
using System;
using System.Collections.Generic;

namespace bolnica.Controller
{
    public class ExaminationController : IExaminationController
    {
        private readonly IExaminationService _examinationService;

        public ExaminationController(IExaminationService service)
        {
            _examinationService = service;
        }
        public void Delete(Examination entity)
        {
            _examinationService.Delete(entity); 
        }

        public void Edit(Examination entity)
        {
            _examinationService.Edit(entity);
        }
        public Examination Get(long id)
        {
            return _examinationService.Get(id);
        }

        public IEnumerable<Examination> GetAll()
        {
            return _examinationService.GetAll();
        }

        public List<Examination> GetAllPrevious()
        {
            return _examinationService.GetAllPrevious();
        }

        public Examination Save(Examination entity)
        {
            return _examinationService.Save(entity);
        }

        public List<Examination> GetExaminationsByFilter(ExaminationDTO examinationDTO, Boolean upcomingOnly)
        {
            return _examinationService.GetExaminationsByFilter(examinationDTO, upcomingOnly);
        }

        public List<Examination> GetFinishedxaminationsByUser(User user)
        {
            return _examinationService.GetFinishedxaminationsByUser(user);
        }

        public List<Examination> GetUpcomingExaminationsByUser(User user)
        {
            return _examinationService.GetUpcomingExaminationsByUser(user);
        }

        public Examination SaveFinishedExamination(Examination examination)
        {
            return _examinationService.SaveFinishedExamination(examination);
        }

        public List<Examination> SearchPreviousExamination(string date, string doctorName, string drugName, string speacialistName, User user)
        {
            return _examinationService.SearchPreviousExamination(date, doctorName, drugName, speacialistName, user);
        }

        public List<Examination> SearchPreviousExaminations(string date, string doctorName, string drugName, string speacialistName, bool Radio1, bool Radio2)
        {
            return _examinationService.SearchPreviousExaminations(date, doctorName, drugName, speacialistName, Radio1, Radio2);
        }
    }
}