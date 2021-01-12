namespace PSW_Pharmacy_Adapter.Prescription_Microservice.Domain.Model
{
    public class Ingredient
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }

        public Ingredient(long id, string name, int quantity)
        {
            Id = id;
            Quantity = quantity;
            Name = name;
        }

        public Ingredient() { }
        
    }
}
