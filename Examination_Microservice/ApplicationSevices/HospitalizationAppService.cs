using Examination_Microservice.ApplicationSevices.Abstract;
using Examination_Microservice.Domain.Model;
using Examination_Microservice.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_Microservice.ApplicationSevices
{
    public class HospitalizationAppService : IHospitalizationAppService
    {
        private readonly IHospitalizationRepository _hospitalizationRepository;

        public HospitalizationAppService(IHospitalizationRepository hospitalizationRepository)
        {
            _hospitalizationRepository = hospitalizationRepository;
        }

        public void Delete(Hospitalization entity)
        {
            _hospitalizationRepository.Delete(entity);
        }

        public void Edit(Hospitalization entity)
        {
            _hospitalizationRepository.Edit(entity);
        }

        public Hospitalization Get(long id)
        {
            return _hospitalizationRepository.Get(id);
        }

        public IEnumerable<Hospitalization> GetAll()
        {
            return _hospitalizationRepository.GetAll();
        }

        public IEnumerable<Hospitalization> GetHospitalizationByDoctor(Doctor doctor)
        {
            return _hospitalizationRepository.GetHospitalizationByDoctor(doctor);
        }

        public Hospitalization Save(Hospitalization entity)
        {
            return _hospitalizationRepository.Save(entity);
        }
    }
}
