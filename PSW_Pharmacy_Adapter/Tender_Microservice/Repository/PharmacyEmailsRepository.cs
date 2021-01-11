using PSW_Pharmacy_Adapter.Tender_Microservice.Domain.Model;
using PSW_Pharmacy_Adapter.Tender_Microservice.Repository.Iabstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PSW_Pharmacy_Adapter.Tender_Microservice.Repository
{
    public class PharmacyEmailsRepository : IPharmacyEmailsRepository
    {
        private readonly MyDbContext _dbContext;

        public PharmacyEmailsRepository(MyDbContext DbContext)
        {
            _dbContext = DbContext;
        }
        public bool Delete(long id)
        {
            throw new NotImplementedException();
        }

        public bool Exists(long id)
        {
            throw new NotImplementedException();
        }

        public PharmacyEmails Get(long id)
             => _dbContext.Email.FirstOrDefault(email => email.Id == id);
        

        public IEnumerable<PharmacyEmails> GetAll()
        {
            List<PharmacyEmails> emails = new List<PharmacyEmails>();
            _dbContext.Email.ToList().ForEach(e => emails.Add(e));
            return emails;
        }

        public PharmacyEmails Save(PharmacyEmails email)
        {
            PharmacyEmails PEmail = _dbContext.Email.SingleOrDefault(e => e.Id == email.Id);
            if (PEmail == null)
            {
                _dbContext.Email.Add(email);
                _dbContext.SaveChanges();
                return email;
            }
            return null;
        }

        public PharmacyEmails Update(PharmacyEmails entity)
        {
            throw new NotImplementedException();
        }
    }
}
