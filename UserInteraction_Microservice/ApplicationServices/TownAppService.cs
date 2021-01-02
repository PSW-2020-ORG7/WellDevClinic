using System.Collections.Generic;
using UserInteraction_Microservice.ApplicationServices.Abstract;
using UserInteraction_Microservice.Domain.Model;
using UserInteraction_Microservice.Repository.Abstract;

namespace UserInteraction_Microservice.ApplicationServices
{
    public class TownAppService : ITownAppService
    {
        private readonly ITownRepository _townRepository;

        public TownAppService(ITownRepository townRepository)
        {
            _townRepository = townRepository;
        }

        public void Delete(Town entity)
        {
            _townRepository.Delete(entity);
        }

        public void Edit(Town entity)
        {
            _townRepository.Edit(entity);
        }

        public Town Get(long id)
        {
            return _townRepository.Get(id);
        }

        public IEnumerable<Town> GetAll()
        {
            return _townRepository.GetAll();
        }

        public Town Save(Town entity)
        {
            return _townRepository.Save(entity);
        }
    }
}
