using System;
using System.Collections.Generic;
using System.Text;
using UserInteraction_Microservice.ApplicationServices.Abstract;
using UserInteraction_Microservice.Domain.Model;
using UserInteraction_Microservice.Repository.Abstract;

namespace UserInteraction_Microservice.ApplicationServices
{
    public class DoctorGradeAppService : IDoctorGradeAppService
    {
        private readonly IDoctorGradeRepository _doctorGradeRepository;

        public DoctorGradeAppService(IDoctorGradeRepository doctorGradeRepository)
        {
            _doctorGradeRepository = doctorGradeRepository;
        }

        public void Delete(DoctorGrade entity)
        {
            _doctorGradeRepository.Delete(entity);
        }

        public void Edit(DoctorGrade entity)
        {
            _doctorGradeRepository.Edit(entity);
        }

        public DoctorGrade Get(long id)
        {
            return _doctorGradeRepository.Get(id);
        }

        public DoctorGrade Save(DoctorGrade entity)
        {
            return _doctorGradeRepository.Save(entity);
        }

        public List<DoctorGrade> GetByDoctor(string doctor)
        {
            return _doctorGradeRepository.GetByDoctor(doctor);
        }

        public IEnumerable<DoctorGrade> GetAll()
        {
            List<DoctorGrade> surveys = (List<DoctorGrade>)_doctorGradeRepository.GetAll();
            foreach (DoctorGrade survey in surveys)
                survey.AverageGrade = GetAverageGrade(survey);
            return surveys;
        }

        public List<DoctorGradeQuestion> GetAverageGrade(DoctorGrade survey)
        {
            List<DoctorGradeQuestion> result = new List<DoctorGradeQuestion>();
            double staff = 0;
            double doctor = 0;
            double hospital = 0;

            foreach (DoctorGradeQuestion grade in survey.DoctorGradeQuestions)
            {
                if (grade.Question.Contains("medical"))
                    staff += grade.Grade;
                else if (grade.Question.Contains("doctor"))
                    doctor += grade.Grade;
                else
                    hospital += grade.Grade;
            }

            staff = Math.Round(staff / 4, 2);
            doctor = Math.Round(doctor / 4, 2);
            hospital = Math.Round(hospital / 4, 2);
            result.Add(new DoctorGradeQuestion(staff, "medical"));
            result.Add(new DoctorGradeQuestion(doctor, "doctor"));
            result.Add(new DoctorGradeQuestion(hospital, "hospital"));
            return result;
        }

        public List<DoctorGradeQuestion> GetAverageGradeDoctor(List<DoctorGrade> surveys)
        {
            double question1 = 0;
            double question2 = 0;
            double question3 = 0;
            double question4 = 0;
            List<DoctorGradeQuestion> result = new List<DoctorGradeQuestion>();
            foreach (DoctorGrade survey in surveys)
            {
                foreach (DoctorGradeQuestion grade in survey.DoctorGradeQuestions)
                {
                    if (grade.Question.Equals("doctor1"))
                        question1 += grade.Grade;
                    else if (grade.Question.Equals("doctor2"))
                        question2 += grade.Grade;
                    else if (grade.Question.Equals("doctor3"))
                        question3 += grade.Grade;
                    else if (grade.Question.Equals("doctor4"))
                        question4 += grade.Grade;
                }

            }
            double sum = (question1 + question2 + question3 + question4) / (surveys.Count * 4);
            question1 = Math.Round(question1 / surveys.Count, 2);
            question2 = Math.Round(question2 / surveys.Count, 2);
            question3 = Math.Round(question3 / surveys.Count, 2);
            question4 = Math.Round(question4 / surveys.Count, 2);
            result.Add(new DoctorGradeQuestion(question1, "question1"));
            result.Add(new DoctorGradeQuestion(question2, "question2"));
            result.Add(new DoctorGradeQuestion(question3, "question3"));
            result.Add(new DoctorGradeQuestion(question4, "question4"));
            result.Add(new DoctorGradeQuestion(sum, "sum"));
            return result;
        }
    }
}
