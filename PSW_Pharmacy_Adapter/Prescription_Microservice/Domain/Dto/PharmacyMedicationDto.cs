using PSW_Pharmacy_Adapter.Model;

namespace PSW_Pharmacy_Adapter.Dto
{
    public class PharmacyMedicationDto
    {
        public string PhName { get; set; }
        public Medication Medicine { get; set; }
        public double Price { get; set; }


        public PharmacyMedicationDto() { }
        public PharmacyMedicationDto(string phName, Medication medicine, double price)
        {
            PhName = phName;
            Medicine = medicine;
            Price = price;
        }
    }
}
