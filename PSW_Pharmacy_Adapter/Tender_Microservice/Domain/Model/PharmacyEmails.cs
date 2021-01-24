using System.ComponentModel.DataAnnotations;


namespace PSW_Pharmacy_Adapter.Tender_Microservice.Domain.Model
{
    public class PharmacyEmails
    {
        [Key]
        public long? Id { get; set; }
        public virtual Email Mail { get; set; }

        public PharmacyEmails() { }

        public PharmacyEmails(long? id, string email)
        {
            Id = id;
            Mail = new Email(email);
        }
    }
}
