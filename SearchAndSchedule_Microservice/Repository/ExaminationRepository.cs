using SearchAndSchedule_Microservice.Domain;
using SearchAndSchedule_Microservice.Domain.Model;
using SearchAndSchedule_Microservice.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SearchAndSchedule_Microservice.Repository
{
    public class ExaminationRepository : IExaminationRepository
    {
        private readonly MyDbContext _myDbContext;

        public ExaminationRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public void Delete(Examination entity)
        {
            _myDbContext.Examination.Remove(entity);
            _myDbContext.SaveChanges();
        }

        public void Edit(Examination entity)
        {
            _myDbContext.Examination.Update(entity);
            _myDbContext.SaveChanges();
        }

        public Examination Get(long id)
        {
             return _myDbContext.Examination.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<Examination> GetAll()
        {
            return _myDbContext.Examination.DefaultIfEmpty().ToList();
        }

        public Examination Save(Examination entity)
        {
            var Examination = _myDbContext.Examination.Add(entity);
            _myDbContext.SaveChanges();
            return Examination.Entity;
        }
    }
}
