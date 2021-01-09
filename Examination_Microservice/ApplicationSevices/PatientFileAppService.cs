using Examination_Microservice.ApplicationSevices.Abstract;
using Examination_Microservice.Domain.Model;
using Examination_Microservice.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_Microservice.ApplicationSevices
{
    public class PatientFileAppService : IPatientFileAppService
    {
        private readonly IPatientFileRepository _patientFileRepository;

        public PatientFileAppService(IPatientFileRepository patientFileRepository)
        {
            this._patientFileRepository = patientFileRepository;
        }

        public void Delete(PatientFile entity)
        {
            _patientFileRepository.Delete(entity);
        }

        public void Edit(PatientFile entity)
        {
            _patientFileRepository.Edit(entity);
        }

        public PatientFile Get(long id)
        {
            return _patientFileRepository.Get(id);
        }

        public IEnumerable<PatientFile> GetAll()
        {
            return _patientFileRepository.GetAll();
        }

        public PatientFile Save(PatientFile entity)
        {
            return _patientFileRepository.Save(entity);
        }
    }
}
