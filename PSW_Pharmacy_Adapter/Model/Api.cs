using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PSW_Pharmacy_Adapter.Model
{
    public class Api
    {
        [Key]
        public string NameOfHospital { get; set; }
        public string ApiKey { get; set; }
        public string Url { get; set; }

        public Api() { }

        public Api(string name, string api, string url)
        {
            NameOfHospital = name;
            ApiKey = api;
            Url = url;
        }
    }
}
