using System;
using System.Collections.Generic;
using System.Text;
using UserInteraction_Microservice.ApplicationServices.Abstract;
using UserInteraction_Microservice.Domain.Model;

namespace UserInteraction_Microservice.ApplicationServices
{
    public class SecretaryAppService : ISecretaryAppService
    {
        public void Delete(Secretary entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(Secretary entity)
        {
            throw new NotImplementedException();
        }

        public Secretary Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Secretary> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Secretary> GetAllEager()
        {
            throw new NotImplementedException();
        }

        public Secretary GetEager(long id)
        {
            throw new NotImplementedException();
        }

        public Secretary Save(Secretary entity)
        {
            throw new NotImplementedException();
        }
    }
}
