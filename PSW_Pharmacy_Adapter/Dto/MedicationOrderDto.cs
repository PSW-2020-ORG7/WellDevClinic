using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW_Pharmacy_Adapter.Dto
{
    public class MedicationOrderDto
    {
        public string medicineName { get; set; }
        public int amount { get; set; }

        public MedicationOrderDto(string medicineName, int amount)
        {
            this.medicineName = medicineName;
            this.amount = amount;
        }
    }
}
