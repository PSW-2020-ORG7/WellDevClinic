using DrugManipulation_Microservice.ApplicationServices.Abstract;
using DrugManipulation_Microservice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrugManipulation_Microservice.Repository.Abstract
{
    public interface IIngredientRepository : ICRUD<Ingredient,long>
    {
    }
}
