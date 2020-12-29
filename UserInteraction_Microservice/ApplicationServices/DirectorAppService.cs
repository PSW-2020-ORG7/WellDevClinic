using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserInteraction_Microservice.ApplicationServices.Abstract;
using UserInteraction_Microservice.Domain.Model;
using UserInteraction_Microservice.Repository.Abstract;

namespace UserInteraction_Microservice.ApplicationServices
{
    public class DirectorAppService : IDirectorAppService
    {
        private readonly IDirectorRepository _directorRepository;

        public DirectorAppService(IDirectorRepository directorRepository)
        {
            _directorRepository = directorRepository;
        }

        public void Delete(Director entity)
        {
            _directorRepository.Delete(entity);
        }

        public void Edit(Director entity)
        {
            _directorRepository.Edit(entity);
        }

        public Director Get(long id)
        {
            return _directorRepository.Get(id);
        }

        public IEnumerable<Director> GetAll()
        {
            return _directorRepository.GetAll().ToList();
        }

        public IEnumerable<Director> GetAllEager()
        {
            return _directorRepository.GetAllEager();
        }

        public Director GetEager(long id)
        {
            return _directorRepository.GetEager(id);
        }

        public Director Save(Director entity)
        {
            return _directorRepository.Save(entity);
        }
    }
}
