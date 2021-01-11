using System;
using System.Collections.Generic;

namespace PSW_Pharmacy_Adapter.Dto
{
    public class MedicationDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public List<string> Ingredients { get; set; }
        public List<string> Alternative { get; set; }
        public double Price { get; set; }
        

        public MedicationDto(){}

        public MedicationDto(string name, long id, int amount)
        {
            Name = name;
            Id = id;
            Amount = amount;
        }

        public MedicationDto(long id, string name, List<string> ingredients, List<string> alternative, double price, int amount)
        {
            Id = id;
            Name = name;
            Ingredients = ingredients;
            Alternative = alternative;
            Price = price;
            Amount = amount;
        }
    }
}
