using Examination_Microservice.Domain;
using Examination_Microservice.Domain.Model;
using Examination_Microservice.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Examination_Microservice.Repository
{
    public class ReferralRepository : IReferralRepository
    {
        private readonly MyDbContext _myDbContext;

        public ReferralRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public void Delete(Referral entity)
        {
            _myDbContext.Referral.Remove(entity);
            _myDbContext.SaveChanges();
        }

        public void Edit(Referral entity)
        {
             _myDbContext.Referral.Update(entity);
            _myDbContext.SaveChanges();
        }

        public Referral Get(long id)
        {
            return _myDbContext.Referral.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Referral> GetAll()
        {
            return _myDbContext.Referral.DefaultIfEmpty().ToList();
        }

        public Referral Save(Referral entity)
        {
            var Referral = _myDbContext.Referral.Add(entity);
            _myDbContext.SaveChanges();
            return Referral.Entity;
        }
    }
}
