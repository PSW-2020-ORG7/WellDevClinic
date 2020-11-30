using bolnica.Model.Dto;
using bolnica.Service;
using Model.Doctor;
using Model.Users;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
    public class DoctorGradeService : IDoctorGradeService
    {

        private readonly IDoctorGradeRepository _doctorGradeRepository;

        public DoctorGradeService(IDoctorGradeRepository doctorGradeRepository)
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
        /// <summary>
        /// Gets all surveys and calls method for calculating average grades
        /// </summary>
        /// <returns>List with all surveys</returns>
        public IEnumerable<DoctorGrade> GetAll()
        {
            List<DoctorGrade> surveys = (List<DoctorGrade>)_doctorGradeRepository.GetEager();
            foreach (DoctorGrade survey in surveys)
                survey.AverageGrade = GetAverageGrade(survey);
            return surveys;
        }
        /// <summary>
        /// Calculates average grades for staff, doctor and hospital in a survey
        /// </summary>
        /// <param name="survey">DoctorGrade object survey</param>
        /// <returns>List with average grades</returns>
        public List<GradeDTO> GetAverageGrade(DoctorGrade survey)
        {
            List<GradeDTO> result = new List<GradeDTO>();
            double staff = 0;
            double doctor = 0;
            double hospital = 0;

            foreach (GradeDTO grade in survey.Grades)
            {
                if (grade.Question.Contains("medical"))
                    staff += grade.Grade;
                else if (grade.Question.Contains("doctor"))
                    doctor += grade.Grade;
                else
                    hospital += grade.Grade;
            }

            staff = staff / 4;
            doctor = doctor / 4;
            hospital = hospital / 4;
            result.Add(new GradeDTO(staff, "medical"));
            result.Add(new GradeDTO(doctor, "doctor"));
            result.Add(new GradeDTO(hospital, "hospital"));
            return result;
        }
        /// <summary>
        /// Calculates average grades for every doctor question from all his surveys
        /// </summary>
        /// <param name="surveys">List of doctor surveys</param>
        /// <returns>List of GradeDTO with average grades</returns>
        public List<GradeDTO> GetAverageGradeDoctor(List<DoctorGrade> surveys)
        {
            double question1 = 0;
            double question2 = 0;
            double question3 = 0;
            double question4 = 0;
            List<GradeDTO> result = new List<GradeDTO>();
            foreach (DoctorGrade survey in surveys)
            {
                foreach(GradeDTO grade in survey.Grades)
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
            question1 = question1 / surveys.Count;
            question2 = question2 / surveys.Count;
            question3 = question3 / surveys.Count;
            question4 = question4 / surveys.Count;
            result.Add(new GradeDTO(question1, "question1"));
            result.Add(new GradeDTO(question2, "question2"));
            result.Add(new GradeDTO(question3, "question3"));
            result.Add(new GradeDTO(question4, "question4"));
            result.Add(new GradeDTO(sum, "sum"));
            return result;
        }

        /// <summary>
        /// Returns surveys of the specified doctor
        /// </summary>
        /// <param name="doctor">Doctor full name</param>
        /// <returns>List of DoctorGrade</returns>
        public List<DoctorGrade> GetByDoctor(string doctor)
        {
            List<DoctorGrade> surveys = (List<DoctorGrade>)GetAll();
            List<DoctorGrade> result = new List<DoctorGrade>();
            foreach(DoctorGrade survey in surveys)
            {
                if (survey.Doctor.ToLower().Equals(doctor.ToLower()))
                    result.Add(survey);
            }

            return result;
        }

        public DoctorGrade Save(DoctorGrade entity)
        {
            return _doctorGradeRepository.Save(entity);
        }
    }
}