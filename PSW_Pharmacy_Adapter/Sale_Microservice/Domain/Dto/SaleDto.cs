namespace PSW_Pharmacy_Adapter.Sale_Microservice.Domain.Dto
{
    public class SaleDto
    {
        public long? Id { get; set; }
        public string PharmacyName { get; set; }
        public string SaleMessage { get; set; }
        public long StartDate { get; set; }
        public long EndDate { get; set; }

        public SaleDto() { }


        public SaleDto(long id, string pharmacyName, string saleMessage, long startDate, long endDate)
        {
            Id = id;
            PharmacyName = pharmacyName;
            SaleMessage = saleMessage;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
