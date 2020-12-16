using System.ComponentModel.DataAnnotations;

namespace PSW_Pharmacy_Adapter.Model
{
    public class Api
    {
        [Key]
        public string NameOfPharmacy { get; set; }
        public string ApiKey { get; set; }
        public string Url { get; set; }
        public bool Subscribed { get; set; }

        public Api() { }

        public Api(string name, string api, string url, bool subscribed)
        {
            NameOfPharmacy = name;
            ApiKey = api;
            Url = url;
            Subscribed = subscribed;
        }
    }
}
