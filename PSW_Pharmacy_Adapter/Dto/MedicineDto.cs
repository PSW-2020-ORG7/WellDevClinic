using System;
using System.Collections.Generic;

namespace PSW_Pharmacy_Adapter.Dto
{
    public class MedicineDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string TypeOfMedicine { get; set; }
        public string FormOfMedicine { get; set; }
        public List<string> Ingredients { get; set; }
        public string Manufactured { get; set; }
        public string PublishingType { get; set; }
        public List<string> ReplacementMedicines { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
        public string Note { get; set; }

        public MedicineDto(){}

        public MedicineDto(string name, long id, int amount)
        {
            Name = name;
            Id = id;
            Amount = amount;
        }

        public MedicineDto(long id, string name, string typeOfMedicine, string formOfMedicine, List<string> ingredients,
            string manufactured, string publishingType, List<string> replacementMedicines, double price, int amount, string note)
        {
            Id = id;
            Name = name;
            TypeOfMedicine = typeOfMedicine;
            FormOfMedicine = formOfMedicine;
            Ingredients = ingredients;
            Manufactured = manufactured;
            PublishingType = publishingType;
            ReplacementMedicines = replacementMedicines;
            Price = price;
            Amount = amount;
            Note = note;
        }
    }
}
