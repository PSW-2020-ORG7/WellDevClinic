using Examination_Microservice.ApplicationSevices.Abstract;
using Examination_Microservice.Domain.Model;
using Examination_Microservice.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_Microservice.ApplicationSevices
{
    public class DiagnosisAppService : IDiagnosisAppService
    {
        private readonly IDiagnosisRepository _diagnosisRepository;

        public DiagnosisAppService(IDiagnosisRepository diagnosisRepository)
        {
            _diagnosisRepository = diagnosisRepository;
        }

        public void Delete(Diagnosis entity)
        {
            _diagnosisRepository.Delete(entity);
        }

        public void Edit(Diagnosis entity)
        {
            _diagnosisRepository.Edit(entity);
        }

        public Diagnosis Get(long id)
        {
            return _diagnosisRepository.Get(id);
        }

        public IEnumerable<Diagnosis> GetAll()
        {
            return _diagnosisRepository.GetAll();
        }

        public Diagnosis Save(Diagnosis entity)
        {
            return _diagnosisRepository.Save(entity);
        }
    }
}
