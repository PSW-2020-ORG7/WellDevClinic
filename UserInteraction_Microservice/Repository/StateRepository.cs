using System;
using System.Collections.Generic;
using System.Linq;
using UserInteraction_Microservice.Domain;
using UserInteraction_Microservice.Domain.Model;
using UserInteraction_Microservice.Repository.Abstract;

namespace UserInteraction_Microservice.Repository
{
    public class StateRepository : IStateRepository
    {
        private readonly MyDbContext _myDbContext;

        public StateRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public void Delete(State entity)
        {
            _myDbContext.State.Remove(entity);
            _myDbContext.SaveChanges();
        }

        public void Edit(State entity)
        {
            _myDbContext.State.Update(entity);
            _myDbContext.SaveChanges();
        }

        public State Get(long id)
        {
            return _myDbContext.State.FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<State> GetAll()
        {
            return _myDbContext.State.DefaultIfEmpty().ToList();
        }

       
        public State Save(State entity)
        {
            var State = _myDbContext.State.Add(entity);
            _myDbContext.SaveChanges();
            return State.Entity;
        }
    }
}
