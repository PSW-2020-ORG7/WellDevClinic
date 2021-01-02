using DrugManipulation_Microservice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrugManipulation_Microservice.ApplicationServices.Abstract
{
    public interface IIngredientAppService : ICRUD<Ingredient,long>
    {
    }
}
