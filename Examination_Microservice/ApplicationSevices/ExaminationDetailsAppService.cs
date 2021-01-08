using Examination_Microservice.ApplicationSevices.Abstract;
using Examination_Microservice.Domain.Model;
using Examination_Microservice.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_Microservice.ApplicationSevices
{
    public class ExaminationDetailsAppService : IExaminationDetailsAppService
    {
        private readonly IExaminationDetailsRepository _examinationDetailsRepository;

        public ExaminationDetailsAppService(IExaminationDetailsRepository examinationDetailsRepository)
        {
            _examinationDetailsRepository = examinationDetailsRepository;
        }

        public void Delete(ExaminationDetails entity)
        {
            _examinationDetailsRepository.Delete(entity);
        }

        public void Edit(ExaminationDetails entity)
        {
            _examinationDetailsRepository.Delete(entity);
        }

        public ExaminationDetails Get(long id)
        {
            return _examinationDetailsRepository.Get(id);
        }

        public IEnumerable<ExaminationDetails> GetAll()
        {
           return _examinationDetailsRepository.GetAll();
        }

        public IEnumerable<ExaminationDetails> GetExaminationDetailsByDoctor(Doctor doctor)
        {
            return _examinationDetailsRepository.GetExaminationDetailsByDoctor(doctor);
        }

        public IEnumerable<ExaminationDetails> GetExaminationDetailsByPatient(Patient patient)
        {
            return _examinationDetailsRepository.GetExaminationDetailsByPatient(patient);
        }

        public ExaminationDetails Save(ExaminationDetails entity)
        {
            return _examinationDetailsRepository.Save(entity);

        }
    }
}
