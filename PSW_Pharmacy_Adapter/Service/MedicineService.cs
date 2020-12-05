using Newtonsoft.Json;
using PSW_Pharmacy_Adapter.Model;
using PSW_Pharmacy_Adapter.Service.Iabstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PSW_Pharmacy_Adapter.Service
{
    public class MedicineService 
    {
        static readonly HttpClient client = new HttpClient();

        /*public static async Task<List<Medication>> GetAllMedication()
        {
            await WpfClient.GetAllDrug();
        }*/
    }
}
