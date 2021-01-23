using System;
using System.Collections.Generic;
using System.Text;

namespace PSW_Wpf_app.Model
{
    public class Drug
    {
        public long Id { get; set; }
        public String Name { get; set; }
        public int Amount { get; set; }
        public Boolean Approved { get; set; }
        public virtual List<Ingredient> Ingredients { get; set; }
        public virtual List<Drug> AlternativeDrugs { get; set; }
        public Drug() { }


    }
}
