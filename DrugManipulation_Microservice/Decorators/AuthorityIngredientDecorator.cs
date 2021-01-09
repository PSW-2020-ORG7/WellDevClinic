using DrugManipulation_Microservice.ApplicationServices.Abstract;
using DrugManipulation_Microservice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DrugManipulation_Microservice.Decorators
{
    public class AuthorityIngredientDecorator
    {
        private readonly IIngredientAppService _ingredientAppService;
        private String Role { get; set; }
        private readonly Dictionary<String, List<String>> AuthorizedUsers;

        public AuthorityIngredientDecorator(IIngredientAppService ingredientAppService)
        {
            _ingredientAppService = ingredientAppService;
            AuthorizedUsers = new Dictionary<string, List<string>>
            {
                ["Delete"] = new List<String>() { "Director" },
                ["Edit"] = new List<String>() { "Director" },
                ["Get"] = new List<String>() { "Director", "Doctor" },
                ["GetAll"] = new List<String>() { "Director", "Doctor" },
                ["Save"] = new List<String>() { "Director" }
            };
        }
        public void Delete(Ingredient entity)
        {
            if (AuthorizedUsers["Delete"].SingleOrDefault(x => x == Role) != null)
                _ingredientAppService.Delete(entity);
        }

        public void Edit(Ingredient entity)
        {
            if (AuthorizedUsers["Edit"].SingleOrDefault(x => x == Role) != null)
                _ingredientAppService.Edit(entity);
        }

        public Ingredient Get(long id)
        {
            if (AuthorizedUsers["Get"].SingleOrDefault(x => x == Role) != null)
                return _ingredientAppService.Get(id);
            return null;
        }

        public IEnumerable<Ingredient> GetAll()
        {
            if (AuthorizedUsers["GetAll"].SingleOrDefault(x => x == Role) != null)
                return _ingredientAppService.GetAll();
            return null;
        }

        public Ingredient Save(Ingredient entity)
        {
            if (AuthorizedUsers["Save"].SingleOrDefault(x => x == Role) != null)
                return _ingredientAppService.Save(entity);
             return null;
        }
    }
}
