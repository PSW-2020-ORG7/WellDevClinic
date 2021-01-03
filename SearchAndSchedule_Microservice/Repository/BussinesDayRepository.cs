using SearchAndSchedule_Microservice.Domain;
using SearchAndSchedule_Microservice.Domain.Model;
using SearchAndSchedule_Microservice.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SearchAndSchedule_Microservice.Repository
{
    public class BussinesDayRepository : IBussinesDayRepository
    {
        private readonly MyDbContext _myDbContext;

        public BussinesDayRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public void Delete(BussinesDay entity)
        {
            _myDbContext.BussinesDay.Remove(entity);
            _myDbContext.SaveChanges();
        }

        public void Edit(BussinesDay entity)
        {
            _myDbContext.BussinesDay.Update(entity);
            _myDbContext.SaveChanges();
        }

        public BussinesDay Get(long id)
        {
            return _myDbContext.BussinesDay.FirstOrDefault(b => b.Id == id);
        }

        public IEnumerable<BussinesDay> GetAll()
        {
            return _myDbContext.BussinesDay.DefaultIfEmpty().ToList();
        }

        public BussinesDay Save(BussinesDay entity)
        {
            var BussinesDay = _myDbContext.BussinesDay.Add(entity);
            _myDbContext.SaveChanges();
            return BussinesDay.Entity;
        }
    }
}
