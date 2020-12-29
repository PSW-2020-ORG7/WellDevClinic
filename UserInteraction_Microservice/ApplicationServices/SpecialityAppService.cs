using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserInteraction_Microservice.ApplicationServices.Abstract;
using UserInteraction_Microservice.Domain.Model;
using UserInteraction_Microservice.Repository.Abstract;

namespace UserInteraction_Microservice.ApplicationServices
{
    class SpecialityAppService : ISpecialityAppService
    {
        private readonly ISpecialityRepository _specialityRepository;

        public SpecialityAppService(ISpecialityRepository specialityRepository)
        {
            _specialityRepository = specialityRepository;
        }

        public void Delete(Speciality entity)
        {
            _specialityRepository.Delete(entity);
        }

        public void Edit(Speciality entity)
        {
            _specialityRepository.Edit(entity);
        }

        public Speciality Get(long id)
        {
            return _specialityRepository.Get(id);
        }

        public IEnumerable<Speciality> GetAll()
        {
            return _specialityRepository.GetAll().ToList();
        }

        public Speciality Save(Speciality entity)
        {
            return _specialityRepository.Save(entity);
        }
    }
}
