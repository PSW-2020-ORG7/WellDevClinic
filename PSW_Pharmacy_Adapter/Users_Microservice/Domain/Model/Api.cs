using PSW_Pharmacy_Adapter.Users_Microservice.Domain.Model;
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
        public virtual Endpoint Url { get; set; }

        public Api() { }

        public Api(string name, string api, int grpcPort, string url)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(api) || string.IsNullOrWhiteSpace(url) && grpcPort == 0)
                throw new ArgumentNullException();
            NameOfPharmacy = name;
            ApiKey = api;
            GrpcPort = grpcPort;
            Url = new Endpoint(url);
        }

        public Api(string name, string api, string url)
        {
            NameOfPharmacy = name;
            ApiKey = api;
            Url = new Endpoint(url);
        }

        
    }
}
