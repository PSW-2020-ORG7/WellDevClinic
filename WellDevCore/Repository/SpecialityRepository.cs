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
    public class SpecialityRepository : CSVGetterRepository<Speciality,long>, ISpecialityRepository
    {
        private readonly MyDbContext myDbContext;

        /*public SpecialityRepository()
        {
            MyContextContextFactory mccf = new MyContextContextFactory();
            this.myDbContext = mccf.CreateDbContext(new string[0]);
        }*/

        public SpecialityRepository(ICSVStream<Speciality> stream, ISequencer<long> sequencer)
       : base(stream, sequencer)
        {
            MyContextContextFactory mccf = new MyContextContextFactory();
            this.myDbContext = mccf.CreateDbContext(new string[0]);
        }

        public Speciality Get(long id)
            => myDbContext.Speciality.FirstOrDefault(speciality => speciality.Id == id);

        public IEnumerable<Speciality> GetAll()
        {
            List<Speciality> result = new List<Speciality>();
            myDbContext.Speciality.ToList().ForEach(speciality => result.Add(speciality));
            return result;
        }
    }
}