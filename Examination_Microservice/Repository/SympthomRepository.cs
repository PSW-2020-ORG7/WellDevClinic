using Examination_Microservice.Domain;
using Examination_Microservice.Domain.Model;
using Examination_Microservice.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Examination_Microservice.Repository
{
    public class SympthomRepository : ISympthomRepository
    {
        private readonly MyDbContext _myDbContext;

        public SympthomRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public void Delete(Sympthom entity)
        {
             _myDbContext.Sympthom.Remove(entity);
            _myDbContext.SaveChanges();
        }

        public void Edit(Sympthom entity)
        {
            _myDbContext.Sympthom.Update(entity);
            _myDbContext.SaveChanges();
        }

        public Sympthom Get(long id)
        {
            return _myDbContext.Sympthom.FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<Sympthom> GetAll()
        {
            return _myDbContext.Sympthom.DefaultIfEmpty().ToList();
        }

        public Sympthom Save(Sympthom entity)
        {
            var Sympthom = _myDbContext.Sympthom.Add(entity);
            _myDbContext.SaveChanges();
            return Sympthom.Entity;
        }
    }
}
