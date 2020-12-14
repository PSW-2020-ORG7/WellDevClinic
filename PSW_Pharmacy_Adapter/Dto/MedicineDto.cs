namespace PSW_Pharmacy_Adapter.Dto
{
    public class MedicineDto
    {
        public string Name { get; set; }
        public long Id { get; set; }
        public int Amount { get; set; }

        public MedicineDto(){}

        public MedicineDto(string name, long id, int amount)
        {
            Name = name;
            Id = id;
            Amount = amount;
        }
    }
}
