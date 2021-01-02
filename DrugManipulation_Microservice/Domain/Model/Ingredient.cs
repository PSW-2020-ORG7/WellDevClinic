using System;
using System.Collections.Generic;
using System.Text;

namespace DrugManipulation_Microservice.Domain.Model
{
    public class Ingredient : IIdentifiable<long>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }

        public Ingredient() { }

        public Ingredient(long id, string name, int quantity)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
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
