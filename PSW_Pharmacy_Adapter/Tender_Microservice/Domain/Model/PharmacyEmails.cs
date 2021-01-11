using System.ComponentModel.DataAnnotations;


namespace PSW_Pharmacy_Adapter.Model
{
    public class PharmacyEmails
    {
        [Key]
        public long? Id { get; set; }
        public string Email { get; set; }

        public PharmacyEmails(long? id, string email)
        {
            Id = id;
            Email = email;
        }
    }
}
