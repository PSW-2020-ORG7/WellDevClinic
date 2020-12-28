using PSW_Pharmacy_Adapter.Dto;
using PSW_Pharmacy_Adapter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW_Pharmacy_Adapter.Mapping
{
    public static class MedicationMapper
    {
        public static Medication MapMedication(MedicationDto medicineDto)
            => new Medication
            {
                Id = medicineDto.Id,
                Name = medicineDto.Name,
                Amount = medicineDto.Amount,
                Approved = true,
                Ingredients = MapIngredient(medicineDto.Ingredients),
                Alternative = MapAlternative(medicineDto.Alternative),
            };

        public static List<Ingredient> MapIngredient(List<String> ingredientsString) {
            List<Ingredient> ingredients = new List<Ingredient>();
            Ingredient ingredient = new Ingredient();
            foreach(String ingredientString in ingredientsString){
                ingredient.Name = ingredientString;
                ingredient.Quantity = 1;
                ingredients.Add(ingredient);
            }
            return ingredients;
        }

        public static List<Medication> MapAlternative(List<String> medicineList) {
            List<Medication> medications = new List<Medication>();
            return medications;
        }
    }
}
