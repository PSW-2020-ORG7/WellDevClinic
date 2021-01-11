using PSW_Pharmacy_Adapter.Medication_Microservice.Domain.Model;

namespace PSW_Pharmacy_Adapter.Medication_Microservice.Domain.Dto
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
