using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW_Pharmacy_Adapter.Model
{
    public class Ingredient
    {
        public string Name { get; set; }
        public int Quantity { get; set; }

        public Ingredient(string name, int quantity)
        {
            Quantity = quantity;
            Name = name;
        }

        public Ingredient() { }
        
    }
}
