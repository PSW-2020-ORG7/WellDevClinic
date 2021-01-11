namespace PSW_Pharmacy_Adapter.Medication_Microservice.Domain.Dto
{
    public class MedicationOrderDto
    {
        public string medicineName { get; set; }
        public int amount { get; set; }

        public MedicationOrderDto(string medicineName, int amount)
        {
            this.medicineName = medicineName;
            this.amount = amount;
        }
    }
}
