using System;
using System.Collections.Generic;
using System.Text;
using UserInteraction_Microservice.ApplicationServices.Abstract;
using UserInteraction_Microservice.Domain.Model;
using UserInteraction_Microservice.Repository.Abstract;

namespace UserInteraction_Microservice.ApplicationServices
{
    public class SecretaryAppService : ISecretaryAppService
    {
        private readonly ISecretaryRepository _secretaryRepository;

        public SecretaryAppService(ISecretaryRepository secretaryRepository)
        {
            _secretaryRepository = secretaryRepository;
        }

        public void Delete(Secretary entity)
        {
            _secretaryRepository.Delete(entity);
        }

        public void Edit(Secretary entity)
        {
            _secretaryRepository.Edit(entity);
        }

        public Secretary Get(long id)
        {
            return _secretaryRepository.Get(id);
        }

        public IEnumerable<Secretary> GetAll()
        {
            return _secretaryRepository.GetAll();    
        }

        public IEnumerable<Secretary> GetAllEager()
        {
            return _secretaryRepository.GetAllEager();
        }

        public Secretary GetEager(long id)
        {
            return _secretaryRepository.GetEager(id);
        }

        public Secretary LogIn(string username, string password)
        {
            return _secretaryRepository.GetUserByCredentials(username, password);
        }

        public Secretary Save(Secretary entity)
        {
            return _secretaryRepository.Save(entity);
        }
    }
}
