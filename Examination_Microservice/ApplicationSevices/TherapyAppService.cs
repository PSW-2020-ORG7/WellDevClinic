using Examination_Microservice.ApplicationSevices.Abstract;
using Examination_Microservice.Domain.Model;
using Examination_Microservice.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_Microservice.ApplicationSevices
{
    public class TherapyAppService : ITherapyAppService
    {
        private readonly ITherapyRepository _therapyRepository;

        public TherapyAppService(ITherapyRepository therapyRepository)
        {
            _therapyRepository = therapyRepository;
        }

        public void Delete(Therapy entity)
        {
            _therapyRepository.Delete(entity);
        }

        public void Edit(Therapy entity)
        {
            _therapyRepository.Edit(entity);
        }

        public Therapy Get(long id)
        {
            return _therapyRepository.Get(id);
        }

        public IEnumerable<Therapy> GetAll()
        {
            return _therapyRepository.GetAll();
        }

        public Therapy Save(Therapy entity)
        {
            return _therapyRepository.Save(entity);
        }
    }
}
