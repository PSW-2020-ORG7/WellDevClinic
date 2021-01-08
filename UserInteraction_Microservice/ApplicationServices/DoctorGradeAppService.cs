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

        public IEnumerable<DoctorGrade> GetAll()
        {
            return _doctorGradeRepository.GetAll();
        }

        public DoctorGrade Save(DoctorGrade entity)
        {
            return _doctorGradeRepository.Save(entity);
        }
    }
}
