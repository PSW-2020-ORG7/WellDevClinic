using bolnica;
using bolnica.Model;
using bolnica.Repository;
using bolnica.Repository.CSV;
using Model.Doctor;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class SpecialityRepository : ISpecialityRepository
    {
        private readonly MyDbContext myDbContext;

        public SpecialityRepository(MyDbContext context)
        {
            myDbContext = context;
        }

        public Speciality Get(long id)
            => myDbContext.Speciality.FirstOrDefault(speciality => speciality.Id == id);

        public IEnumerable<Speciality> GetEager()
        {
            List<Speciality> result = new List<Speciality>();
            myDbContext.Speciality.ToList().ForEach(speciality => result.Add(speciality));
            return result;
        }
    }
}