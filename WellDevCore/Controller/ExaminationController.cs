using bolnica.Controller;
using bolnica.Service;
using Model.Director;
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

        public IEnumerable<Examination> GetUpcomingExaminationsByRoomAndPeriod(Room room, Period period)
        {
            return _examinationService.GetUpcomingExaminationsByRoomAndPeriod(room, period);
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

        public List<Examination> GetFinishedExaminationsByUser(long id)
        {
            return _examinationService.GetFinishedExaminationsByUser(id);
        }

        public List<Examination> GetUpcomingExaminationsByUser(long id)
        {
           return _examinationService.GetUpcomingExaminationsByUser(id);
            

        }

        public Examination SaveFinishedExamination(Examination examination)
        {
            return _examinationService.SaveFinishedExamination(examination);
        }

        /*public Examination NewExamination(long doctorId, String period, long patientId)
        {
            Examination examination = _examinationService.NewExamination(doctorId, period, patientId);
            return examination;
        }*/
        public Examination NewExamination(long doctorId, Period period, long patientId)
        {
            Examination examination = _examinationService.NewExamination(doctorId, period, patientId);
            return examination;
        }

        public void EditPrevious(Examination entity)
        {
             _examinationService.EditPrevious(entity);
        }

        public Examination GetPrevious(long id)
        {
            return _examinationService.GetPrevious(id);
        }

        public List<Examination> GetUpcomingExaminationsByUser(User user)
        {
            return _examinationService.GetUpcomingExaminationsByUser(user);
        }

        public List<Examination> GetFinishedExaminationsByUser(User user)
        {
            return _examinationService.GetFinishedExaminationsByUser(user);

        }
        public List<Examination> GetAllUpcomingExaminations()
        {
            return _examinationService.GetAllUpcomingExaminations();
        }
    }
}