using bolnica.Controller;
using bolnica.Model.Dto;
using bolnica.Service;
using Model.Doctor;
using Model.Users;
using Service;
using System;
using System.Collections.Generic;

namespace Controller
{
    public class DoctorGradeController : IDoctorGradeController
    {
        private readonly IDoctorGradeService _doctorGradeService;

        public DoctorGradeController(IDoctorGradeService doctorGradeService)
        {
            _doctorGradeService = doctorGradeService;
        }

        public void Delete(DoctorGrade entity)
        {
            _doctorGradeService.Delete(entity);

        }

        public void Edit(DoctorGrade entity)
        {
            _doctorGradeService.Edit(entity);
        }

        public DoctorGrade Get(long id)
        {
            return _doctorGradeService.Get(id);
        }

        public IEnumerable<DoctorGrade> GetAll()
        {
            return _doctorGradeService.GetAll();
        }

        public List<GradeDTO> GetAverageGrade(DoctorGrade survey)
        {
           return _doctorGradeService.GetAverageGrade(survey);

        }

        public List<GradeDTO> GetAverageGradeDoctor(List<DoctorGrade> surveys)
        {
            return _doctorGradeService.GetAverageGradeDoctor(surveys);
        }

        public List<DoctorGrade> GetByDoctor(string doctor)
        {
            return _doctorGradeService.GetByDoctor(doctor);
        }

        public DoctorGrade Save(DoctorGrade entity)
        {
            return _doctorGradeService.Save(entity);
        }
    }
}