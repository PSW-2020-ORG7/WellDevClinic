using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace PSW_Pharmacy_Adapter.DTO
{
    public class ApiDTO
    {
        public string Api { get; set; }
        public string Url { get; set; }

        public ApiDTO() { }

        public ApiDTO(string api, string url)
        {
            Api = api;
            Url = url;
        }
    }
}
