using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PSW_Pharmacy_Adapter.Pharmacy_Microservice.Domain.Model
{
    public class Api
    {
        [Key]
        public string NameOfPharmacy { get;  set; }
        public string ApiKey { get; set; }
        public int GrpcPort { get; set; }
        public string Url { get; set; }


        public Api(string name, string api, int grpcPort, string url)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(api) || string.IsNullOrWhiteSpace(url) && grpcPort == 0)
                throw new ArgumentNullException();
            NameOfPharmacy = name;
            ApiKey = api;
            GrpcPort = grpcPort;
            Url = url;
        }

        public Api(string name, string api, string url)
        {
            NameOfPharmacy = name;
            ApiKey = api;
            Url = url;
        }

        public void ChangeUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentNullException();
            Url = url;
        }

        public Api() { }
    }
}
