using System;
using System.Collections.Generic;

namespace PSW_Pharmacy_Adapter.Dto
{
    public class MedicationDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string TypeOfMedicine { get; set; }
        public string FormOfMedicine { get; set; }
        public List<string> Ingredients { get; set; }
        public string Manufactured { get; set; }
        public string PublishingType { get; set; }
        public List<string> Alternative { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
        public string Note { get; set; }

        public MedicationDto(){}

        public MedicationDto(string name, long id, int amount)
        {
            Name = name;
            Id = id;
            Amount = amount;
        }

        public MedicationDto(long id, string name, string typeOfMedicine, string formOfMedicine, List<string> ingredients,
            string manufactured, string publishingType, List<string> alternative, double price, int amount, string note)
        {
            Id = id;
            Name = name;
            TypeOfMedicine = typeOfMedicine;
            FormOfMedicine = formOfMedicine;
            Ingredients = ingredients;
            Manufactured = manufactured;
            PublishingType = publishingType;
            Alternative = alternative;
            Price = price;
            Amount = amount;
            Note = note;
        }
    }
}
