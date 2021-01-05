using Examination_Microservice.Domain;
using Examination_Microservice.Domain.Model;
using Examination_Microservice.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Examination_Microservice.Repository
{
    public class HospitalizationRepository : IHospitalizationRepository
    {
        private readonly MyDbContext _myDbContext;

        public HospitalizationRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public void Delete(Hospitalization entity)
        {
            _myDbContext.Hospitalization.Remove(entity);
            _myDbContext.SaveChanges();
        }

        public void Edit(Hospitalization entity)
        {
            _myDbContext.Hospitalization.Update(entity);
            _myDbContext.SaveChanges();
        }

        public Hospitalization Get(long id)
        {
            return _myDbContext.Hospitalization.FirstOrDefault(h => h.Id == id);
        }

        public IEnumerable<Hospitalization> GetAll()
        {
            return _myDbContext.Hospitalization.DefaultIfEmpty().ToList();
        }

        public Hospitalization Save(Hospitalization entity)
        {
            var Hospitalization = _myDbContext.Hospitalization.Add(entity);
            _myDbContext.SaveChanges();
            return Hospitalization.Entity;
        }
    }
}
