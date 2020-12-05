using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW_Pharmacy_Adapter.Model
{
    public class Medication
    {

        public String Name { get; set; }
        public long Id { get; set; }
        public int Amount { get; set; }
        public Boolean Approved { get; set; }
        public virtual List<Ingredient> Ingredients { get; set; }
        public virtual List<Medication> Alternative { get; set; }

        public Medication() { }

        public Medication(long id, String name, int amount, Boolean approved, List<Ingredient> ingredients, List<Medication> alternative)
        {
            this.Id = id;
            this.Name = name;
            this.Amount = amount;
            this.Approved = approved;
            this.Ingredients = ingredients;
            this.Alternative = alternative;
        }


    }
}
