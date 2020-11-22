using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace PSW_Pharmacy_Adapter.DTO
{
    public class ApiDTO
    {
        public string api { get; set; }
        public string url { get; set; }

        public ApiDTO() { }

        public override string ToString()
        {
            return this.api;
        }
    }
}
