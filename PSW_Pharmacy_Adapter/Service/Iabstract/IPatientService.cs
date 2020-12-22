﻿using PSW_Pharmacy_Adapter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW_Pharmacy_Adapter.Service.Iabstract
{
    interface IPatientService
    {
        public Task<List<Patient>> GetAllPatients();
    }
}