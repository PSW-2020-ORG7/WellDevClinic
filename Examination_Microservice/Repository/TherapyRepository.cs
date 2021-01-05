using Examination_Microservice.Domain;
using Examination_Microservice.Domain.Model;
using Examination_Microservice.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Examination_Microservice.Repository
{
    public class TherapyRepository : ITherapyRepository
    {
        private readonly MyDbContext _myDbContext;

        public TherapyRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public void Delete(Therapy entity)
        {
            _myDbContext.Therapy.Remove(entity);
            _myDbContext.SaveChanges();
        }

        public void Edit(Therapy entity)
        {
            _myDbContext.Therapy.Update(entity);
            _myDbContext.SaveChanges();
        }

        public Therapy Get(long id)
        {
            return _myDbContext.Therapy.FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Therapy> GetAll()
        {
            return _myDbContext.Therapy.DefaultIfEmpty().ToList();
        }

        public Therapy Save(Therapy entity)
        {
            var Therapy = _myDbContext.Therapy.Add(entity);
            _myDbContext.SaveChanges();
            return Therapy.Entity;
        }
    }
}
