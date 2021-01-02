using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrugManipulation_Microservice.ApplicationServices.Abstract;
using DrugManipulation_Microservice.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace DrugManipulation_Interlayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController :  ControllerBase
    {
        private readonly IIngredientAppService _ingredientAppService;

        public IngredientController(IIngredientAppService ingredientAppService)
        {
            _ingredientAppService = ingredientAppService;
        }

        [HttpGet]
        public List<Ingredient> GetAll()
        {
            return _ingredientAppService.GetAll().DefaultIfEmpty().ToList();
        }

        [HttpGet]
        [Route("lazy/{id?}")]
        public Ingredient GetLazy(long id)
        {
            return _ingredientAppService.Get(id);
        }

        [HttpPut]
        public void Edit(Ingredient ingredient)
        {
            _ingredientAppService.Edit(ingredient);
        }

        [HttpPost]
        public Ingredient AddIngrerdient([FromBody] Ingredient ingredient)
        {
            return _ingredientAppService.Save(ingredient);
        }
    }
}