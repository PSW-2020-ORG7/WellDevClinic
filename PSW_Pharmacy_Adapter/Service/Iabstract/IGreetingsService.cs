﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PSW_Pharmacy_Adapter.Service.Iabstract
{
    public interface IGreetingsService
    {
        public Task<HttpResponseMessage> GreetPharmacy(string id);
    }
}
