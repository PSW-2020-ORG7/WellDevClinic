using Examination_Microservice.ApplicationSevices.Abstract;
using Examination_Microservice.Domain.Model;
using Examination_Microservice.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_Microservice.ApplicationSevices
{
    public class SympthomAppService : ISympthomAppService
    {
        private readonly ISympthomRepository _sympthomRepository;

        public SympthomAppService(ISympthomRepository sympthomRepository)
        {
            _sympthomRepository = sympthomRepository;
        }

        public void Delete(Sympthom entity)
        {
            _sympthomRepository.Delete(entity);
        }

        public void Edit(Sympthom entity)
        {
            _sympthomRepository.Edit(entity);
        }

        public Sympthom Get(long id)
        {
            return _sympthomRepository.Get(id);
        }

        public IEnumerable<Sympthom> GetAll()
        {
            return _sympthomRepository.GetAll();
        }

        public Sympthom Save(Sympthom entity)
        {
            return _sympthomRepository.Save(entity);

        }
    }
}
