namespace PSW_Pharmacy_Adapter.Dto
{
    public class ActionAndBenefitDto
    {
        public long? Id { get; set; }
        public string PharmacyName { get; set; }
        public string MessageAboutAction { get; set; }
        public long StartDate { get; set; }
        public long EndDate { get; set; }

        public ActionAndBenefitDto() { }


        public ActionAndBenefitDto(long id, string pharmacyName, string messageAboutAction, long startDate, long endDate)
        {
            Id = id;
            PharmacyName = pharmacyName;
            MessageAboutAction = messageAboutAction;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
