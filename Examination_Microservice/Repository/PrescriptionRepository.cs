using Examination_Microservice.Domain;
using Examination_Microservice.Domain.Model;
using Examination_Microservice.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Examination_Microservice.Repository
{
    public class PrescriptionRepository : IPrescriptionRepository
    {
        private readonly MyDbContext _myDbContext;

        public PrescriptionRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public void Delete(Prescription entity)
        {
            _myDbContext.Prescription.Remove(entity);
            _myDbContext.SaveChanges();
        }

        public void Edit(Prescription entity)
        {
            _myDbContext.Prescription.Update(entity);
            _myDbContext.SaveChanges();
        }

        public Prescription Get(long id)
        {
            return _myDbContext.Prescription.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Prescription> GetAll()
        {
            return _myDbContext.Prescription.DefaultIfEmpty().ToList();
        }

        public Prescription Save(Prescription entity)
        {
            var Prescription = _myDbContext.Prescription.Add(entity);
            _myDbContext.SaveChanges();
            return Prescription.Entity;
        }
    }
}
