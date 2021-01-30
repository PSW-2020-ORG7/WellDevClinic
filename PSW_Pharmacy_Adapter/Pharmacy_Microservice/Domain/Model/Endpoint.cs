using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PSW_Pharmacy_Adapter.Users_Microservice.Domain.Model
{
    public class Endpoint
    {
        public string Url { get; private set; }

        public Endpoint(string url)
        {
            Url = url;
            Validate();
        }

        private void Validate()
        {
            if (!Url.StartsWith("http://")|| !Url.EndsWith("/")) 
                throw new ArgumentException("Invalid argument", nameof(Url));
        }
    }
}
