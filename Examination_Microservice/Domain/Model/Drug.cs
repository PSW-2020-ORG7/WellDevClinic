using System;
using System.Collections.Generic;
using System.Text;

namespace Examination_Microservice.Domain.Model
{
    public class Drug : IIdentifiable<long>
    {
        public long Id { get; set; }
        public String Name { get; set; }
        public int Amount { get; set; }
        public Boolean Approved { get; set; }
        public virtual List<Ingredient> Ingredients { get; set; }
        public virtual List<Drug> Alternative { get; set; }

        public Drug() { }

        public Drug(long id, string name, int amount, bool approved, List<Ingredient> ingredients, List<Drug> alternative)
        {
            Id = id;
            Name = name;
            Amount = amount;
            Approved = approved;
            Ingredients = ingredients;
            Alternative = alternative;
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
