using System;
using System.Collections.Generic;
using System.Text;
using UserInteraction_Microservice.ApplicationServices.Abstract;
using UserInteraction_Microservice.Domain.Model;
using UserInteraction_Microservice.Repository.Abstract;

namespace UserInteraction_Microservice.ApplicationServices
{
    public class DoctorAppService : IDoctorAppService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorAppService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public void Delete(Doctor entity)
        {
            _doctorRepository.Delete(entity);
        }

        public void Edit(Doctor entity)
        {
            _doctorRepository.Edit(entity);
        }

        public Doctor Get(long id)
        {
            return _doctorRepository.Get(id);
        }

        public IEnumerable<Doctor> GetAll()
        {
            return _doctorRepository.GetAll();
        }

        public IEnumerable<Doctor> GetAllEager()
        {
            return _doctorRepository.GetAllEager();
        }

        public Doctor GetEager(long id)
        {
            return _doctorRepository.GetEager(id);
        }

        public Doctor Save(Doctor entity)
        {
            return _doctorRepository.Save(entity);
        }
    }
}
