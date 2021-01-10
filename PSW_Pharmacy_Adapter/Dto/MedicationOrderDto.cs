using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW_Pharmacy_Adapter.Dto
{
    public class MedicationOrderDto
    {
        public string Name { get; set; }
        public int Amount { get; set; }

        public MedicationOrderDto(string name, int amount)
        {
            Name = name;
            Amount = amount;
        }
    }
}
