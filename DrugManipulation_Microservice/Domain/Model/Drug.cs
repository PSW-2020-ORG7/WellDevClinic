using System;
using System.Collections.Generic;
using System.Text;

namespace DrugManipulation_Microservice.Domain.Model
{
    public class Drug : IIdentifiable<long>
    {
        public long Id { get; set; }
        public String Name { get; set; }
        public int Amount { get; set; }
        public Boolean Approved { get; set; }
        public virtual List<Ingredient> Ingredients { get; set; }
        public virtual List<Drug> AlternativeDrugs { get; set; }
        public Drug() { }

        public Drug(long id, string name, int amount, bool approved, List<Ingredient> ingredients, List<Drug> alternativeDrugs)
        {
            Id = id;
            Name = name;
            Amount = amount;
            Approved = approved;
            Ingredients = ingredients;
            AlternativeDrugs = alternativeDrugs;
        }
        public Drug(long id, String name, int amount, Boolean approved, List<Ingredient> ingredients)
        {
            this.Id = id;
            this.Name = name;
            this.Amount = amount;
            this.Approved = approved;
            this.Ingredients = ingredients;
        }
        public Drug(string name, int amount, bool approved, List<Ingredient> ingredients, List<Drug> alternative)
        {
            Name = name;
            Amount = amount;
            Approved = approved;
            Ingredients = ingredients;
            AlternativeDrugs = alternative;
        }
        public Drug(long id, String name)
        {
            Id = id;
            Name = name;
        }
        public Drug(long id)
        {
            Id = id;
        }

        public long GetId()
        {
            return Id;
        }

        public void SetId(long id)
        {
            Id = id;
        }
    }
}
