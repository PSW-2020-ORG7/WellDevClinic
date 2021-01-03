using SearchAndSchedule_Microservice.ApplicationServices.Abstract;
using SearchAndSchedule_Microservice.Domain.Model;
using SearchAndSchedule_Microservice.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace SearchAndSchedule_Microservice.ApplicationServices
{
    public class BussinesDayAppService : IBussinesDayAppService
    {
        private readonly IBussinesDayRepository _bussinesDayRepository;

        public BussinesDayAppService(IBussinesDayRepository bussinesDayRepository)
        {
            _bussinesDayRepository = bussinesDayRepository;
        }

        public void Delete(BussinesDay entity)
        {
            _bussinesDayRepository.Delete(entity);
        }

        public void Edit(BussinesDay entity)
        {
            _bussinesDayRepository.Edit(entity);
        }

        public BussinesDay Get(long id)
        {
            return _bussinesDayRepository.Get(id);
        }

        public IEnumerable<BussinesDay> GetAll()
        {
            return _bussinesDayRepository.GetAll();
        }

        public BussinesDay Save(BussinesDay entity)
        {
            return _bussinesDayRepository.Save(entity);
        }
    }
}
