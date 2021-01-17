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
            List<DoctorGrade> surveys = _doctorGradeRepository.GetByDoctor(doctor);
            foreach (DoctorGrade survey in surveys)
                survey.AverageGrade = GetAverageGrade(survey);
            return surveys;
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
            double[] parts = new double[] { 0, 0, 0 };

            foreach (DoctorGradeQuestion grade in survey.DoctorGradeQuestions)
            {
                if (grade.Question.Contains("medical"))
                    parts[0] += grade.Grade;
                else if (grade.Question.Contains("doctor"))
                    parts[1] += grade.Grade;
                else
                    parts[2] += grade.Grade;
            }
            for (int i = 0; i <= 2; i++)
            {
                parts[i] = Math.Round(parts[i] / 4, 2);
            }
            result.Add(new DoctorGradeQuestion(parts[0], "medical"));
            result.Add(new DoctorGradeQuestion(parts[1], "doctor"));
            result.Add(new DoctorGradeQuestion(parts[2], "hospital"));
            return result;
        }

        public List<DoctorGradeQuestion> GetAverageGradeDoctor(List<DoctorGrade> surveys)
        {
            double[] questions = new double[] { 0, 0, 0, 0 };
            List<DoctorGradeQuestion> result = new List<DoctorGradeQuestion>();
            foreach (DoctorGrade survey in surveys)
            {
                questions = SumByQuestion(survey.DoctorGradeQuestions, questions);
            }
            double sum = (questions[0] + questions[1] + questions[2] + questions[3]) / (surveys.Count * 4);
            result.Add(new DoctorGradeQuestion(sum, "sum"));
            for (int i = 0; i <= 3; i++)
            {
                questions[i] = Math.Round(questions[i] / surveys.Count, 2);
                result.Add(new DoctorGradeQuestion(questions[i], "question" + i));
            }
            return result;
        }

        public double[] SumByQuestion(List<DoctorGradeQuestion> grades, double[] questions)
        {
            foreach (DoctorGradeQuestion grade in grades)
            {
                if (grade.Question.Equals("doctor1"))
                    questions[0] += grade.Grade;
                else if (grade.Question.Equals("doctor2"))
                    questions[1] += grade.Grade;
                else if (grade.Question.Equals("doctor3"))
                    questions[2] += grade.Grade;
                else if (grade.Question.Equals("doctor4"))
                    questions[3] += grade.Grade;
            }
            return questions;
        }
    }
}
