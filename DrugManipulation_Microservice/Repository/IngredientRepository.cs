using DrugManipulation_Microservice.Domain;
using DrugManipulation_Microservice.Domain.Model;
using DrugManipulation_Microservice.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DrugManipulation_Microservice.Repository
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly MyDbContext _myDbContext;

        public IngredientRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public void Delete(Ingredient entity)
        {
            _myDbContext.Ingredient.Remove(entity);
            _myDbContext.SaveChanges();
        }

        public void Edit(Ingredient entity)
        {
            _myDbContext.Ingredient.Update(entity);
            _myDbContext.SaveChanges();
        }

        public Ingredient Get(long id)
        {
            return _myDbContext.Ingredient.FirstOrDefault(d => d.Id == id);
        }

        public IEnumerable<Ingredient> GetAll()
        {
            return _myDbContext.Ingredient.DefaultIfEmpty().ToList();
        }

        public Ingredient Save(Ingredient entity)
        {
            var Ingredient = _myDbContext.Ingredient.Add(entity);
            _myDbContext.SaveChanges();
            return Ingredient.Entity;
        }
    }
}
