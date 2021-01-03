using SearchAndSchedule_Microservice.ApplicationServices.Abstract;
using SearchAndSchedule_Microservice.Domain.Model;
using SearchAndSchedule_Microservice.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace SearchAndSchedule_Microservice.ApplicationServices
{
    public class ExaminationAppService : IExaminationAppService
    {
        private readonly IExaminationRepository _examinationRepository;

        public ExaminationAppService(IExaminationRepository examinationRepository)
        {
            _examinationRepository = examinationRepository;
        }

        public void Delete(Examination entity)
        {
            _examinationRepository.Delete(entity);
        }

        public void Edit(Examination entity)
        {
            _examinationRepository.Edit(entity);
        }

        public Examination Get(long id)
        {
            return _examinationRepository.Get(id);
        }

        public IEnumerable<Examination> GetAll()
        {
            return _examinationRepository.GetAll();
        }

        public Examination Save(Examination entity)
        {
            return _examinationRepository.Save(entity);
        }
    }
}
