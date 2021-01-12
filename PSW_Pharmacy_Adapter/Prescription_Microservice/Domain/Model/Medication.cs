using System.Collections.Generic;

namespace PSW_Pharmacy_Adapter.Prescription_Microservice.Domain.Model
{
    public class Medication
    {

        public long Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public bool Approved { get; set; }
        public virtual List<Ingredient> Ingredients { get; set; }
        public virtual List<Medication> Alternative { get; set; }

        public Medication() { }

        public Medication(string name, int amount)
        {
            Name = name;
            Amount = amount;
        }

        public Medication(long id, string name, int amount, bool approved, List<Ingredient> ingredients, List<Medication> alternative)
        {
            Id = id;
            Name = name;
            Amount = amount;
            Approved = approved;
            Ingredients = ingredients;
            Alternative = alternative;
        }
    }
}
