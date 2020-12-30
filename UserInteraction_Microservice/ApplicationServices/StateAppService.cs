using System.Collections.Generic;
using UserInteraction_Microservice.ApplicationServices.Abstract;
using UserInteraction_Microservice.Domain.Model;
using UserInteraction_Microservice.Repository.Abstract;

namespace UserInteraction_Microservice.ApplicationServices
{
    public class StateAppService : IStateAppService
    {
        private readonly IStateRepository _stateRepository;

        public StateAppService(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }

        public void Delete(State entity)
        {
            _stateRepository.Delete(entity);
        }

        public void Edit(State entity)
        {
            _stateRepository.Edit(entity);
        }

        public State Get(long id)
        {
            return _stateRepository.Get(id);
        }

        public IEnumerable<State> GetAll()
        {
            return _stateRepository.GetAll();
        }

        public IEnumerable<State> GetAllEager()
        {
            return _stateRepository.GetAllEager();
        }

        public State GetEager(long id)
        {
            return _stateRepository.GetEager(id);
        }

        public State Save(State entity)
        {
            return _stateRepository.Save(entity);
        }
    }
}
