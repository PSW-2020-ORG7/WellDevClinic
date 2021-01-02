using DrugManipulation_Microservice.Domain;
using DrugManipulation_Microservice.Domain.Model;
using DrugManipulation_Microservice.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DrugManipulation_Microservice.Repository
{
    public class DrugRepository : IDrugRepository
    {
        private readonly MyDbContext _myDbContext;

        public DrugRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public void Delete(Drug entity)
        {
            _myDbContext.Drug.Remove(entity);
            _myDbContext.SaveChanges();
        }

        public void Edit(Drug entity)
        {
            _myDbContext.Drug.Update(entity);
            _myDbContext.SaveChanges();
        }

        public Drug Get(long id)
        {
            return _myDbContext.Drug.FirstOrDefault(d => d.Id == id);
        }

        public IEnumerable<Drug> GetAll()
        {
            return _myDbContext.Drug.DefaultIfEmpty().ToList();
        }
        
        public IEnumerable<Drug> GetNotApprovedDrugs()
        {
            return _myDbContext.Drug.Where(d => d.Approved==false).DefaultIfEmpty().ToList();
        }

        public Drug Save(Drug entity)
        {
            var Drug = _myDbContext.Drug.Add(entity);
            _myDbContext.SaveChanges();
            return Drug.Entity;
        }

    }
}
