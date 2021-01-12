using PSW_Pharmacy_Adapter.Prescription_Microservice.Domain.Dto;
using PSW_Pharmacy_Adapter.Prescription_Microservice.Domain.Model;
using System.Collections.Generic;

namespace PSW_Pharmacy_Adapter.Prescription_Microservice.Domain.Mapping
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

        public static List<Ingredient> MapIngredient(List<string> ingredientsString) {
            List<Ingredient> ingredients = new List<Ingredient>();
            Ingredient ingredient = new Ingredient();
            if(ingredientsString != null)
                foreach(string ingredientString in ingredientsString){
                    ingredient.Name = ingredientString;
                    ingredient.Quantity = 1;
                    ingredients.Add(ingredient);
                }
            return ingredients;
        }

        public static List<Medication> MapMedicationList(List<MedicationDto> medicationDtos)
        {
            List<Medication> medicationDto = new List<Medication>();
            foreach (MedicationDto medication in medicationDtos)
                medicationDto.Add(MapMedication(medication));
            return medicationDto;
        }

        public static List<Medication> MapAlternative(List<string> medicineList) {
            List<Medication> medications = new List<Medication>();
            return medications;
        }
    }
}
