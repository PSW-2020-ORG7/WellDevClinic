

using Model.Users;
using System;
using bolnica.Repository;
using System.Collections.Generic;
using System.Linq;
using bolnica.Model;

namespace Repository
{
   public class DirectorRepository :IDirectorRepository, IEagerRepository<Director, long>
   {
        private readonly IAddressRepository _addressRepository;
        private readonly ITownRepository _townRepository;
        private readonly IStateRepository _stateRepository;
        private readonly MyDbContext myDbContext;

        public DirectorRepository(IAddressRepository addressRepository,
            ITownRepository townRepository, IStateRepository stateRepository, MyDbContext context)
        {
            _addressRepository = addressRepository;
            _townRepository = townRepository;
            _stateRepository = stateRepository;
            myDbContext = context;

        }
        public User GetUserByUsername(string username) 
        {
            IEnumerable<Director> entities = this.GetEager();
            foreach (Director entity in entities)
            {
                if (entity.Username == username)
                    return entity;
            }
            return null;
        }

        public IEnumerable<Director> GetAllEager()
        {
            List<Director> directors = GetEager().ToList();
            for (int i = 0; i < directors.Count; i++)
            {
                directors[i] = GetEager(directors[i].GetId());
            }
            return directors;
        }

        public Director GetEager(long id)
        {
            Director director = Get(id);
            director.Address = _addressRepository.GetEager(director.Address.GetId());
            director.Address.Town = _townRepository.GetEager(director.Address.Town.GetId());
            director.Address.Town.State = _stateRepository.GetEager(director.Address.Town.State.GetId());
            return director;
        }

        public Director Save(Director entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(Director entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Director entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Director> GetEager()
        {
            throw new NotImplementedException();
        }

        public Director Get(long id)
        {
            throw new NotImplementedException();
        }
    }
}