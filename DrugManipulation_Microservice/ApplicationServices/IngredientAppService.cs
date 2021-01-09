using DrugManipulation_Microservice.ApplicationServices.Abstract;
using DrugManipulation_Microservice.Domain.Model;
using DrugManipulation_Microservice.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrugManipulation_Microservice.ApplicationServices
{
    public class IngredientAppService : IIngredientAppService
    {
        private readonly IIngredientRepository _ingredientRepository;

        public IngredientAppService(IIngredientRepository ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }

        public void Delete(Ingredient entity)
        {
            _ingredientRepository.Delete(entity);
        }

        public void Edit(Ingredient entity)
        {
            _ingredientRepository.Edit(entity);
        }

        public Ingredient Get(long id)
        {
            return _ingredientRepository.Get(id);
        }

        public IEnumerable<Ingredient> GetAll()
        {
            return _ingredientRepository.GetAll();
        }

        public Ingredient Save(Ingredient entity)
        {
            return _ingredientRepository.Save(entity);
        }
    }
}
