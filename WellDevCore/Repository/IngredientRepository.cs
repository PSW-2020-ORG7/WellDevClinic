using bolnica;
using bolnica.Model;
using bolnica.Repository;
using bolnica.Repository.CSV;
using Model.PatientSecretary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
   public class IngredientRepository : CSVRepository<Ingredient, long>, IIngredientRepository
   {
        private readonly MyDbContext myDbContext;

        /*public IngredientRepository()
        {
            MyContextContextFactory mccf = new MyContextContextFactory();
            this.myDbContext = mccf.CreateDbContext(new string[0]);
        }*/

        public IngredientRepository(ICSVStream<Ingredient> stream, ISequencer<long> sequencer)
    : base(stream, sequencer)
        {
            MyContextContextFactory mccf = new MyContextContextFactory();
            this.myDbContext = mccf.CreateDbContext(new string[0]);
        }

        public void Delete(Ingredient entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(Ingredient entity)
        {
            throw new NotImplementedException();
        }

        public Ingredient Get(long id)
            => myDbContext.Ingredient.FirstOrDefault(ingredient => ingredient.Id == id);

        public IEnumerable<Ingredient> GetAll()
        {
            List<Ingredient> result = new List<Ingredient>();
            myDbContext.Ingredient.ToList().ForEach(ingredient => result.Add(ingredient));
            return result;
        }

        public Ingredient Save(Ingredient entity)
        {
            throw new NotImplementedException();
        }
    }
}