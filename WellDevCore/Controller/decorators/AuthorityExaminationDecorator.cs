using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Dto;
using Model.PatientSecretary;
using Model.Users;

namespace bolnica.Controller.decorators
{
    public class AuthorityExaminationDecorator : IExaminationController
    {
        private IExaminationController ExaminationController;
        public String Role { get; set; }
        private Dictionary<String, List<String>> AuthorizedUsers;

        public AuthorityExaminationDecorator(IExaminationController examinationController, string role)
        {
            ExaminationController = examinationController;
            Role = role;
            AuthorizedUsers = new Dictionary<string, List<string>>();
            AuthorizedUsers["Delete"] = new List<String>() { "Doctor", "Patient", "Secretary" };
            AuthorizedUsers["Edit"] = new List<String>() { "Secretary" };
            AuthorizedUsers["Get"] = new List<String>() { "Doctor", "Patient", "Secretary" };
            AuthorizedUsers["GetAll"] = new List<String>() { "Doctor", "Patient", "Secretary" };
            AuthorizedUsers["GetAllPrevious"] = new List<String>() { "Doctor", "Patient", "Secretary" };
            AuthorizedUsers["GetExaminationsByFilter"] = new List<String>() { "Secretary" };
            //AuthorizedUsers["GetFinishedExaminationsByUser"] = new List<String>() { "Doctor" };
            AuthorizedUsers["GetFinishedExaminationsByUser"] = new List<String>() { "Patient" };
            AuthorizedUsers["GetUpcomingExaminationsByUser"] = new List<String>() { "Patient", "Doctor", "Director" };
            AuthorizedUsers["Save"] = new List<String>() { "Patient", "Secretary", "Doctor" };
            AuthorizedUsers["SaveFinishedExamination"] = new List<String>() { "Doctor" };
        }

        public void Delete(Examination entity)
        {
            if (AuthorizedUsers["Delete"].SingleOrDefault(x => x == Role) != null)
                ExaminationController.Delete(entity);
        }

        public void Edit(Examination entity)
        {
            if (AuthorizedUsers["Edit"].SingleOrDefault(x => x == Role) != null)
                ExaminationController.Edit(entity);
        }

        public void EditPrevious(Examination entity)
        {
            throw new NotImplementedException();
        }

        public Examination Get(long id)
        {
            if (AuthorizedUsers["Get"].SingleOrDefault(x => x == Role) != null)
                return ExaminationController.Get(id);
            else
                return null;
        }

        public IEnumerable<Examination> GetAll()
        {
            if (AuthorizedUsers["GetAll"].SingleOrDefault(x => x == Role) != null)
                return ExaminationController.GetAll();
            else
                return null;
        }

        public List<Examination> GetAllPrevious()
        {
            if (AuthorizedUsers["GetAllPrevious"].SingleOrDefault(x => x == Role) != null)
                return ExaminationController.GetAllPrevious();
            else
                return null;
        }

        public List<Examination> GetExaminationsByFilter(ExaminationDTO examinationDTO, bool upcomingOnly)
        {
            if (AuthorizedUsers["GetExaminationsByFilter"].SingleOrDefault(x => x == Role) != null)
                return ExaminationController.GetExaminationsByFilter(examinationDTO, upcomingOnly);
            else
                return null;
        }

        public List<Examination> GetFinishedExaminationsByUser(User user)
        {
            if (AuthorizedUsers["GetFinishedExaminationsByUser"].SingleOrDefault(x => x == Role) != null)
                return ExaminationController.GetFinishedExaminationsByUser(user);
            else
                return null;
        }

        public List<Examination> GetFinishedExaminationsByUser(long id)
        {
            if (AuthorizedUsers["GetFinishedExaminationsByUser"].SingleOrDefault(x => x == Role) != null)
                return ExaminationController.GetFinishedExaminationsByUser(id);
            else
                return null;
        }

        public Examination GetPrevious(long id)
        {
            throw new NotImplementedException();
        }

        public List<Examination> GetUpcomingExaminationsByUser(User user)
        {
            if (AuthorizedUsers["GetUpcomingExaminationsByUser"].SingleOrDefault(x => x == Role) != null)
                return ExaminationController.GetUpcomingExaminationsByUser(user);
            else
                return null;
        }

        public Examination NewExamination(long DoctorId, Period Period, long PatientId)
        {
            throw new NotImplementedException();
        }
        public List<Examination> GetUpcomingExaminationsByUser(long id)
        {
            throw new NotImplementedException();
        }

        public Examination Save(Examination entity)
        {
            if (AuthorizedUsers["Save"].SingleOrDefault(x => x == Role) != null)
                return ExaminationController.Save(entity);
            else
                return null;
        }

        public Examination SaveFinishedExamination(Examination examination)
        {
            if (AuthorizedUsers["SaveFinishedExamination"].SingleOrDefault(x => x == Role) != null)
                return ExaminationController.SaveFinishedExamination(examination);
            else
                return null;
        }
    }
}
