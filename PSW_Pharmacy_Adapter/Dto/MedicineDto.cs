using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW_Pharmacy_Adapter.Dto
{
    public class MedicineDto
    {
        public String Name { get; set; }
        public long Id { get; set; }
        public int Amount { get; set; }

        public MedicineDto(){}

        public MedicineDto(string name, long id, int amount)
        {
            Name = name;
            Id = id;
            Amount = amount;
        }
    }
}
